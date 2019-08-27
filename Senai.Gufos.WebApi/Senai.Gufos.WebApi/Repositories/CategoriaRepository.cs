﻿using Senai.Gufos.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Repositories
{
    public class CategoriaRepository
    {
            public List<Categorias> Listar()
            {
                using(GufosContext ctx = new GufosContext())
                {

                    return ctx.Categorias.ToList();

                }
            }

            public void Cadastrar(Categorias categoria)
            {
             
                using(GufosContext ctx = new GufosContext())
                {
                    ctx.Categorias.Add(categoria);
                    ctx.SaveChanges();
                }   

            }

            public Categorias BuscarPorId (int id)
        {
                using(GufosContext ctx = new GufosContext())
                {

                    return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);

                }
        }

            public void Deletar(int id)
        {
                using(GufosContext ctx = new GufosContext())
                {
                    Categorias categoriaBuscada = ctx.Categorias.Find(id);
                    ctx.Categorias.Remove(categoriaBuscada);
                    ctx.SaveChanges();
                }
        }

            public void Atualizar(Categorias categoria)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Categorias categoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
                categoriaBuscada.Nome = categoria.Nome;
                ctx.Categorias.Update(categoriaBuscada);
                ctx.SaveChanges();
            }
        }
    }
}
