using AutoMapper;
using eDoc.Model.Common.Enums;
using eDoc.Model.Extensions;
using eDoc.Model.Managers.ContextState;
using eDoc.Web.Base;
using eDoc.Web.Managers;
using eDoc.Web.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDoc.Web.Controllers
{
    public class HomeController : Controller
    {
        IContextStateManager _contextState;
        public HomeController(IMapper mapper)
        {
            var mp = mapper;
            _contextState = new CookieManager(new HttpContextWrapper(System.Web.HttpContext.Current));
        }

        public ActionResult Index(bool force = false)
        {
            var model = new LatestBlogsViewModel()
            {
                Blogs = new List<ShortBlogPostViewModel>()
                {
                    new ShortBlogPostViewModel()
                    {
                        Title = "Що таке Lorem Ipsum?",
                        Author = "Creator1",
                        Avatar = "/Content/img/if_boy_403024.png",
                        Content = "Вже давно відомо, що читабельний зміст буде заважати зосередитись людині, яка оцінює композицію сторінки. Сенс використання Lorem Ipsum полягає в тому, що цей текст має більш-менш нормальне розподілення літер на відміну від, наприклад, \"Тут іде текст. Тут іде текст.\" Це робить текст схожим на оповідний. Багато програм верстування та веб-дизайну використовують Lorem Ipsum як зразок і пошук за терміном \"lorem ipsum\" відкриє багато веб-сайтів, які знаходяться ще в зародковому стані. Різні версії Lorem Ipsum з'явились за минулі роки, деякі випадково, деякі було створено зумисно (зокрема, жартівливі).",
                        CreationDate = DateTime.Now.WithOffset(- DateTimeUnit.Day.ToMinutes(5))
                    },
                    new ShortBlogPostViewModel()
                    {
                        Title = "Чому ми ним користуємось?",
                        Author = "Creator2",
                        Avatar = "/Content/img/male3-512.png",
                        Content = "Lorem Ipsum - це текст-\"риба\", що використовується в друкарстві та дизайні. Lorem Ipsum є, фактично, стандартною \"рибою\" аж з XVI сторіччя, коли невідомий друкар взяв шрифтову гранку та склав на ній підбірку зразків шрифтів. \"Риба\" не тільки успішно пережила п'ять століть, але й прижилася в електронному верстуванні, залишаючись по суті незмінною. Вона популяризувалась в 60-их роках минулого сторіччя завдяки виданню зразків шрифтів Letraset, які містили уривки з Lorem Ipsum, і вдруге - нещодавно завдяки програмам комп'ютерного верстування на кшталт Aldus Pagemaker, які використовували різні версії Lorem Ipsum.",
                        CreationDate = DateTime.Now.WithOffset(- DateTimeUnit.Day.ToMinutes(15))
                    },
                    new ShortBlogPostViewModel()
                    {
                        Title = "Звідки він походить?",
                        Author = "Creator1",
                        Avatar = "/Content/img/if_boy_403024.png",
                        Content = "На відміну від поширеної думки Lorem Ipsum не є випадковим набором літер. Він походить з уривку класичної латинської літератури 45 року до н.е., тобто має більш як 2000-річну історію. Річард Макклінток, професор латини з коледжу Хемпдін-Сидні, що у Вірджінії, вивчав одне з найменш зрозумілих латинських слів - consectetur - з уривку Lorem Ipsum, і у пошуку цього слова в класичній літературі знайшов безсумнівне джерело. Lorem Ipsum походить з розділів 1.10.32 та 1.10.33 цицеронівського \"de Finibus Bonorum et Malorum\" (\"Про межі добра і зла\"), написаного у 45 році до н.е. Цей трактат з теорії етики був дуже популярним в епоху Відродження. Перший рядок Lorem Ipsum, \"Lorem ipsum dolor sit amet...\" походить з одного з рядків розділу 1.10.32.",
                        CreationDate = DateTime.Now.WithOffset(- DateTimeUnit.Day.ToMinutes(5))
                    },
                }
            };
            //var cookie = _contextState.GetItem("test-key");
            //if (cookie != null && cookie.Equals("lol kek"))
            //    return RedirectToAction("About");
            //_contextState.AddOrUpdateItem("test-key", "lol kek");
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}