using System;
using System.Collections.Generic;
using System.Text;

public interface ISubject
{
    void Register(IObserver observable);

    void Unregister(IObserver observable);

    void NotifyObservers();
}
