using System;
using System.Collections.Generic;

namespace ProjectMange.Services.Dtos
{
    /// <summary>
    /// Common分页列表输出模型
    ///</summary>
    public class PowerInfoListOutput
    {

        public PowerInfoListOutput()
        {
            Children = new List<PowerInfoListOutput>();
        }
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ActionUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MenuIconUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PowerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? Sort { get; set; }

        /// <summary>
        /// 子级
        /// </summary>
        public List<PowerInfoListOutput> Children { get; set; }

        /// <summary>
        /// 是否末级
        /// </summary>
        public bool IsLeaf { get; set; }


    }
    public static class TreeOptionResultModelExtension
    {
          #region string扩展
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<PowerInfoListOutput> ToTreeList(this List<PowerInfoListOutput> list)
        {
            var trees = new List<PowerInfoListOutput>();
            var ids = list.Select(x => x.ParentId).Distinct().ToList();
            var top = list.Where(a => ids.Contains(a.PowerId)).ToList();
            foreach (var item in top)
            {
                trees.Add(GetChildrenTree(list, item));
            }
            return trees;
        }

        private static PowerInfoListOutput GetChildrenTree(List<PowerInfoListOutput> data, PowerInfoListOutput item)
        {
            var tree = new PowerInfoListOutput
            {
                PowerId = item.PowerId,
                ParentId = item.ParentId,
                ActionUrl = item.ActionUrl,
                Description = item.Description,
                HttpMethod = item.HttpMethod,
                Sort = item.Sort,
                Name = item.Name,
            };

            var childs = data.Where(a => a.ParentId == item.PowerId).ToList();
            if (childs.Count == 0)
            {
                tree.IsLeaf = true;
                tree.Children = null;
                return tree;
            }
            else
            {
                tree.IsLeaf = false;
                if (!tree.IsLeaf)
                {
                    foreach (var child in childs)
                    {
                        tree.Children.Add(GetChildrenTree(data, child));
                    }
                }
            }
            return tree;
        }
        #endregion
    }

}

