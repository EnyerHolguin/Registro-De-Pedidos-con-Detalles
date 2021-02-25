using Microsoft.EntityFrameworkCore;
using RegistroPedidos.DAL;
using RegistroPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroPedidos.BLL
{
    public class OrdenesBLL
    {
        private Contexto _contexto { get; set; }

        public OrdenesBLL(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<bool> Guardar(Ordenes ordenes)
        {
            if (!await Existe(ordenes.OrdenId))
                return await Insertar(ordenes);
            else
                return await Modificar(ordenes);
        }

        private async Task<bool> Existe(int id)
        {
            bool ok = false;

            try
            {
                ok = await _contexto.Ordenes.AnyAsync(s => s.OrdenId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        private async Task<bool> Insertar(Ordenes ordenes)
        {
            bool ok = false;

            try
            {
                await _contexto.Ordenes.AddAsync(ordenes);
                ok = await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        private async Task<bool> Modificar(Ordenes ordenes)
        {
            bool ok = false;

            try
            {
                Detached(ordenes.OrdenId);
                _contexto.Entry(ordenes).State = EntityState.Modified;
                ok = await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return ok;

        }

        public async Task<Ordenes> Buscar(int id)
        {
            Ordenes ordenes;

            try
            {
                ordenes = await _contexto.Ordenes
                    .Where(s => s.OrdenId == id)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return ordenes;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool ok = false;
            try
            {
                var registro = await _contexto.Ordenes.FindAsync(id);
                if (registro != null)
                {
                    _contexto.Entry(registro).State = EntityState.Deleted;
                    ok = await _contexto.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        public async Task<List<Ordenes>> GetSuplidores(Expression<Func<Ordenes, bool>> criterio)
        {
            List<Ordenes> lista = new List<Ordenes>();

            try
            {
                lista = await _contexto.Ordenes.Where(criterio).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }

        private void Detached(int ordenesId)
        {
            var aux = _contexto
                .Set<Ordenes>()
                .Local
                .FirstOrDefault(s => s.OrdenId == ordenesId);

            if (aux != null)
                _contexto.Entry(aux).State = EntityState.Detached;
        }

    }
}
