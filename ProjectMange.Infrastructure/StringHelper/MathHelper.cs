
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMange.Infrastructure.StringHelper
{
    public static class MathHelper
    {
        /// <summary>
        /// 保留小数点位数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static decimal ToRound(this decimal? value,int num = 2)
        {
            return Math.Round(value ?? 0, num);
        }


        
    }
}
