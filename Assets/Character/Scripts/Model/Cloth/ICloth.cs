using System.Collections.Generic;
public interface ICloths
{
    void Initilze(CallBack callback);
    void PutOn(CallBack callback);
    void TakeOff(CallBack callback);
    void Dispose();
}