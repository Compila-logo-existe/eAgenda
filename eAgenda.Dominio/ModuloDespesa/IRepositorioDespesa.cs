﻿using eAgenda.Dominio.Compartilhado;

namespace eAgenda.Dominio.ModuloDespesa;

public interface IRepositorioDespesa : IRepositorio<Despesa>
{
    Despesa SelecionarPorId(Guid idRegistro);
}