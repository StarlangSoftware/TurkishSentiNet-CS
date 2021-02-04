# For Developers

You can also see [Java](https://github.com/starlangsoftware/TurkishSentiNet), [Python](https://github.com/starlangsoftware/TurkishSentiNet-Py), [Cython](https://github.com/starlangsoftware/TurkishSentiNet-Cy), [Swift](https://github.com/starlangsoftware/TurkishSentiNet-Swift), or [C++](https://github.com/starlangsoftware/TurkishSentiNet-CPP) repository.

# Detailed Description

+ [SentiNet](#sentinet)
+ [SentiSynSet](#sentisynset)

## SentiNet

Duygu sözlüğünü yüklemek için

	a = SentiNet()

Belirli bir alana ait duygu sözlüğünü yüklemek için

	SentiNet(string fileName)
	a = SentiNet("dosya.txt");

Belirli bir synsete ait duygu synsetini elde etmek için

	SentiSynSet getSentiSynSet(String id)

## SentiSynSet

Bir SentiSynset elimizdeyken onun pozitif skorunu

	double GetPositiveScore()

negatif skorunu

	double GetNegativeScore()

polaritysini

	PolarityType GetPolarity()
