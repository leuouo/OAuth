using OAuth.Domain.Model;
using OAuth.Service.Interfaces;
using System;

namespace OAuth.Web.Models
{
    /// <summary>
    /// 项目的缓存信息
    /// </summary>
    public class ProjectInfo
    {
        private readonly ICacheManager cache;
        private readonly IProjectService projectService;

        public ProjectInfo(IProjectService projectService, ICacheManager cache)
        {
            this.cache = cache;
            this.projectService = projectService;
        }

        /// <summary>
        /// 当前项目信息
        /// </summary>
        /// <param name="appid">项目唯一编码</param>
        /// <returns></returns>
        public Project CurrentProject(string appid)
        {
            var currentProject = cache.Get<Project>(appid);
            if (currentProject == null)
            {
                try
                {
                    currentProject = projectService.GetProjectById(new Guid(appid));
                    //缓存当前项目信息
                    cache.Set(appid, currentProject);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return currentProject;
        }


        public void Clear()
        {
            cache.Clear();
        }
    }
}