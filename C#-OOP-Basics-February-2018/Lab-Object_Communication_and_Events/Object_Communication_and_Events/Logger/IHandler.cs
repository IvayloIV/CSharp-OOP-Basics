using System;
using System.Collections.Generic;
using System.Text;


public interface IHandler
{
    void Handle(LogType logType, string str);

    void SetSuccessor(IHandler successor);
}