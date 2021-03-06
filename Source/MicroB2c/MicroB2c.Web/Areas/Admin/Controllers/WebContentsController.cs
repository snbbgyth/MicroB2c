﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using MicroB2c.Core.DbModel;
using MicroB2c.Core.IDAL;
using MicroB2c.Web.DAL;
using MicroB2c.Web.DAL.Manage;
using MicroB2c.Web.DAL.MySql;

namespace MicroB2c.Web.Areas.Admin.Controllers
{
    [MyAuthorize(Roles = "Admin,Edit")]
    public class WebContentsController : BaseController
    {
        private IWebContentDal _webContentDal;
        private IWebContentTypeDal _webContentTypeDal;
        private IMenuTypeDal _menuTypeDal;

        public WebContentsController()
        {
            _webContentDal = DependencyResolver.Current.GetService<IWebContentDal>();
            _webContentTypeDal = DependencyResolver.Current.GetService<IWebContentTypeDal>();
            _menuTypeDal = DependencyResolver.Current.GetService<IMenuTypeDal>();
        }

        // GET: Admin/WebContents
        public async Task<ActionResult> Index(string menuTypeId, string webContentTypeId, string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            ViewBag.MenuTypeId = menuTypeId;
            ViewBag.WebContentTypeId = webContentTypeId;
            IEnumerable<WebContent> entityList =await WebContentManage.QueryByMenuTypeIdAndWebContentTypeId(menuTypeId,webContentTypeId);
            if (entityList.Any())
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    entityList = entityList.Where(s => (s.Content != null && s.Content.Contains(searchString))
                                                                          || (s.Title != null && s.Title.Contains(searchString))
                                                                          || (s.Creater != null && s.Creater.Contains(searchString))
                                                                          || (s.LastModifier != null && s.LastModifier.Contains(searchString)));
                }
                entityList = entityList.OrderByDescending(s => s.LastModifyDate);
            }
            ViewBag.MenuTypes = await  WebContentManage.QuerySelectListMenuTypes();
            ViewBag.WebContentTypes = await WebContentManage.QuerySelectListWebContentTypesByMenuTypeId(menuTypeId);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(entityList.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/WebContents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebContent webContent = await _webContentDal.QueryByIdAsync(id);
            if (webContent == null)
            {
                return HttpNotFound();
            }
            webContent.WebContentType = await _webContentTypeDal.QueryByIdAsync(webContent.WebContentTypeId);
            return View(webContent);
        }

        // GET: Admin/WebContents/Create
        public async Task<ActionResult> Create()
        {
            var webContent = new WebContent();
            webContent.WebContentTypeList = await _webContentTypeDal.QueryAllAsync();
            return View(webContent);
        }

        // POST: Admin/WebContents/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(WebContent webContent)
        {
            InitInsert(webContent);
            await _webContentDal.InsertAsync(webContent);
            return RedirectToAction("Index");
        }

        // GET: Admin/WebContents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebContent webContent = await _webContentDal.QueryByIdAsync(id);
            if (webContent == null)
            {
                return HttpNotFound();
            }
            webContent.WebContentType = await _webContentTypeDal.QueryByIdAsync(webContent.WebContentTypeId);
            webContent.WebContentTypeList = await _webContentTypeDal.QueryAllAsync();
            return View(webContent);
        }

        // POST: Admin/WebContents/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(WebContent webContent)
        {
            InitModify(webContent);
            await _webContentDal.ModifyAsync(webContent);
            return RedirectToAction("Index");
        }

        // GET: Admin/WebContents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebContent webContent = await _webContentDal.QueryByIdAsync(id);
            if (webContent == null)
            {
                return HttpNotFound();
            }
            webContent.WebContentType = await _webContentTypeDal.QueryByIdAsync(webContent.WebContentTypeId);
            return View(webContent);
        }

        // POST: Admin/WebContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _webContentDal.DeleteByIdAsync(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            base.Dispose(disposing);
        }
    }
}
