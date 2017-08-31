using System.Collections.Generic;

public interface ICharacterDna
{
    void changeDna(EnumUmaParamters dna, float dnaValue);
    List<UmaDnaItem> getUmaDna();
}