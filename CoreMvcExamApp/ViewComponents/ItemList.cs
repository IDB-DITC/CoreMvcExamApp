using CoreMvcExamApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvcExamApp.ViewComponents
{
    public class ItemList: ViewComponent
    {




        public IViewComponentResult Invoke(List<InvoiceItem> data)
        {

			ViewBag.Count = data.Count;
			ViewBag.Total = data.Sum(i => i.ItemTotal);

			return View(data);
        }



    }
}
