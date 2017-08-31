using System.Collections.Generic;

public interface ICharacterCloth
{
    void Initialize();
    void PutOn(List<ClothModel> cms);
    void PutOn(ClothModel cm);
    void TakeOff(ClothModel cm);
    void TakeOffAll();
    void Dispose();
}