using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMange.Infrastructure.Utils
{
    public class SnowflakeId
    {
        /// <summary>
        /// 初始基准时间戳，小于当前时间即可(分布式项目请保持此时间戳完全一致)
        /// </summary>
        private const long TwEpoch = 154627200000L;

        /// <summary>
        /// 机器码字节。4个字节用来保存机器码(定义为Long类型会出现，最大偏移量64位，所以左移64位没有意义)
        /// </summary>
        private const int WorkerIdBits = 5;

        /// <summary>
        /// 数据字节数
        /// </summary>
        private const int DatacenterIdBits = 5;

        /// <summary>
        /// 计算器字节数，计算器字节数，12个字节用来保持计数码
        /// </summary>
        private const int SequenceBits = 12;

        /// <summary>
        /// 最大机器ID所占的数位
        /// </summary>
        private const long MaxWorkerId = -1L ^ (-1L << WorkerIdBits);

        /// <summary>
        /// 最大数据ID
        /// </summary>
        private const long MaxDatacenterId = -1L ^ (-1L << DatacenterIdBits);

        /// <summary>
        /// 机器码数据左移位数，就是后面计数器占用的位数
        /// </summary>
        private const int WorkerIdShift = SequenceBits;//12
        /// <summary>
        /// 数据ID左移位数
        /// </summary>
        private const int DatacenterIdShift = SequenceBits + WorkerIdBits;//17
        /// <summary>
        /// 时间戳左移动位数就是机器码+计数器总字节数+数据字节数
        /// </summary>
        private const int TimestampLeftShift = SequenceBits + WorkerIdBits + DatacenterIdBits;//22
        /// <summary>
        /// 一微秒内可以产生计数，如果达到该值则等到下一微妙在进行生成
        /// </summary>
        private const long SequenceMask = -1L ^ (-1L << SequenceBits);//4096

        /// <summary>
        /// 毫秒计数器
        /// </summary>
        private long _sequence = 0L;
        /// <summary>
        /// 最后一次的时间戳
        /// </summary>
        private long _lastTimestamp = -1L;
        /// <summary>
        ///10位的数据机器位中的高位  机器码
        /// </summary>
        public long WorkerId { get; protected set; }
        /// <summary>
        /// 10位的数据机器位中的低位  数据ID
        /// </summary>
        public long DatacenterId { get; protected set; }
        /// <summary>
        /// 线程锁对象
        /// </summary>
        private readonly object _lock = new object();
        /// <summary>
        /// 基于Twitter的snowflake算法
        /// </summary>
        /// <param name="workerId">10位的数据机器位中的高位，默认不应该超过5位(5byte) 32</param>
        /// <param name="datacenterId"> 10位的数据机器位中的低位，默认不应该超过5位(5byte) 32</param>
        /// <param name="sequence">初始序列</param>
        public SnowflakeId(long workerId, long datacenterId, long sequence = 0L)
        {
            WorkerId = workerId;
            DatacenterId = datacenterId;
            _sequence = sequence;

            if (workerId > MaxWorkerId || workerId < 0)
            {
                throw new ArgumentException($"worker Id can't be greater than {MaxWorkerId} or less than 0");
            }

            if (datacenterId > MaxDatacenterId || datacenterId < 0)
            {
                throw new ArgumentException($"datacenter Id can't be greater than {MaxDatacenterId} or less than 0");
            }
        }
        public long CurrentId { get; private set; }

        public long NextId()
        {
            lock (_lock)
            {
                var timestamp = CurrentUTCTimeStamp();
                if (timestamp < _lastTimestamp)
                {
                    //TODO 是否可以考虑直接等待？
                    throw new Exception(
                        $"Clock moved backwards or wrapped around. Refusing to generate id for {_lastTimestamp - timestamp} ticks");
                    //如果当前时间戳比上一次生成ID时时间戳还小，抛出异常，因为不能保证现在生成的ID之前没有生成过
                    //throw new Exception(
                    //    string.Format("Clock moved backwards.  Refusing to generate id for {0} milliseconds", _lastTimestamp - timestamp));
                }

                if (_lastTimestamp == timestamp)
                {
                    //同一微妙中生成ID
                    _sequence = (_sequence + 1) & SequenceMask;//用&运算计算该微秒内产生的计数是否已经到达上限
                    if (_sequence == 0)
                    {
                        //一微妙内产生的ID计数已达上限，等待下一微妙
                        timestamp = TilNextMillis(_lastTimestamp);
                    }
                }
                else
                {
                    _sequence = 0L;
                }
                _lastTimestamp = timestamp;//把当前时间戳保存为最后生成ID的时间戳
                CurrentId = ((timestamp - TwEpoch) << TimestampLeftShift) |
                         (DatacenterId << DatacenterIdShift) |
                         (WorkerId << WorkerIdShift) | _sequence;

                return CurrentId;
            }
        }

        /// <summary>
        /// 获取时间截
        /// </summary>
        /// <param name="lastTimestamp"></param>
        /// <returns></returns>
        private long TilNextMillis(long lastTimestamp)
        {
            var timestamp = CurrentUTCTimeStamp();
            while (timestamp <= lastTimestamp)
            {
                timestamp = CurrentUTCTimeStamp();
            }
            return timestamp;
        }

        /// <summary>
        /// 获取UTC时间戳 可选秒级/毫秒级
        /// </summary>
        /// <returns></returns>
        public static long CurrentUTCTimeStamp(bool isMinseconds = true)
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long times = Convert.ToInt64(isMinseconds ? ts.TotalMilliseconds : ts.TotalSeconds);
            return times;
        }
    }
}
