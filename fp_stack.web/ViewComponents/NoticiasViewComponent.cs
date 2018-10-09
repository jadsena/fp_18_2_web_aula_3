using fp_stack.core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fp_stack.web.ViewComponents
{
    public class NoticiasViewComponent : ViewComponent
    {
        private NoticiasServices _noticiaService;

        public NoticiasViewComponent(core.Services.NoticiasServices noticiasServices)
        {
            _noticiaService = noticiasServices;
        }
        public async Task<IViewComponentResult> InvokeAsync(int total, bool noticiasUrgentes=false)
        {
            var view = noticiasUrgentes ? "noticiasUrgentes" : "noticias";
            var itens = _noticiaService.GetItens(total);

            return View(view, itens);
        }

    }
}
