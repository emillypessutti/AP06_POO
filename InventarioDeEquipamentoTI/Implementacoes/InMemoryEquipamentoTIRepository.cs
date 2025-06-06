using System;
using InventarioDeEquipamentoTI.Interfaces;
using InventarioDeEquipamentoTI.Modelos;

namespace InventarioDeEquipamentoTI.Implementacoes;

public class InMemoryEquipamentoTIRepository: IEquipamentoTIRepository
{
    private readonly List<EquipamentoTI> _equipamentos = new();

    public void Adicionar(EquipamentoTI equipamento)
    {
        _equipamentos.Add(equipamento);
    }

    public EquipamentoTI? ObterPorId(Guid id)
    {
        return _equipamentos.FirstOrDefault(e => e.Id == id);
    }

    public List<EquipamentoTI> ObterTodos()
    {
        return _equipamentos;
    }

    public void Atualizar(EquipamentoTI equipamento)
    {
        var existente = ObterPorId(equipamento.Id);
        if (existente != null)
        {
            _equipamentos.Remove(existente);
            _equipamentos.Add(equipamento);
        }
    }

    public bool Remover(Guid id)
    {
        var equipamento = ObterPorId(id);
        if (equipamento != null)
        {
            _equipamentos.Remove(equipamento);
            return true;
        }
        return false;
    }
}