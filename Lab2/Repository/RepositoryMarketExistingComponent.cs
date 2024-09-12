using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class RepositoryMarketExistingComponent<T>
    where T : IComputerComponent
{
    private readonly IList<T> _repository;

    public RepositoryMarketExistingComponent(IList<T> repository)
    {
        _repository = repository;
    }

    public void AddComponent(T component)
    {
        _repository.Add(component);
    }

    public T ChooseComponent(int index)
    {
        return _repository[index];
    }
}