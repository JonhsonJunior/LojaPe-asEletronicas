using LojaPeçasEletronicas.Data;
using LojaPeçasEletronicas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaPeçasEletronicas.Controllers
{
    public class PagamentosController : Controller
    {
        private readonly LojaPeçasEletronicasContext _context;

        public PagamentosController(LojaPeçasEletronicasContext context)
        {
            _context = context;
        }

        // GET: Pagamentos
        public async Task<IActionResult> Index()
        {
            var pagamentos = await _context.Pagamento.Include(p => p.Cliente).ToListAsync();
            return View(pagamentos);
        }

        // GET: Pagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var pagamento = await GetPagamentoByIdAsync(id.Value);
            if (pagamento == null) return NotFound();

            return View(pagamento);
        }

        // GET: Pagamentos/Create
        public IActionResult Create()
        {
            PopulateClientesDropDownList();
            return View();
        }

        // POST: Pagamentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagamentoId,ClienteId,ValorTotal,FormaDePagamento,StatusDoPagamento,Data")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamento);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Compra realizada com sucesso!";
                return RedirectToAction("Index", "Produtos");

            }
            PopulateClientesDropDownList(pagamento.ClienteId);
            return View(pagamento);
        }

        // GET: Pagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var pagamento = await GetPagamentoByIdAsync(id.Value);
            if (pagamento == null) return NotFound();

            PopulateClientesDropDownList(pagamento.ClienteId);
            return View(pagamento);
        }

        // POST: Pagamentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagamentoId,ClienteId,ValorTotal,FormaDePagamento,StatusDoPagamento,Data")] Pagamento pagamento)
        {
            if (id != pagamento.PagamentoId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoExists(pagamento.PagamentoId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateClientesDropDownList(pagamento.ClienteId);
            return View(pagamento);
        }

        // GET: Pagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var pagamento = await GetPagamentoByIdAsync(id.Value);
            if (pagamento == null) return NotFound();

            return View(pagamento);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamento = await _context.Pagamento.FindAsync(id);
            if (pagamento != null)
            {
                _context.Pagamento.Remove(pagamento);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoExists(int id)
        {
            return _context.Pagamento.Any(e => e.PagamentoId == id);
        }

        private async Task<Pagamento?> GetPagamentoByIdAsync(int id)
        {
            return await _context.Pagamento.Include(p => p.Cliente).FirstOrDefaultAsync(m => m.PagamentoId == id);
        }

        private void PopulateClientesDropDownList(object? selectedCliente = null)
        {
            var clientesQuery = from c in _context.Cliente
                                orderby c.Nome
                                select c;
            ViewBag.ClienteId = new SelectList(clientesQuery.AsNoTracking(), "ClienteId", "Nome", selectedCliente);
        }
    }
}