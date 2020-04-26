# TurkishSentiNet-CS

You can also see [Java](https://github.com/starlangsoftware/TurkishSentiNet), [Python](https://github.com/starlangsoftware/TurkishSentiNet-Py), or [C++](https://github.com/starlangsoftware/TurkishSentiNet-CPP) repository.

## SentiNet

Turkish SentiNet (HisNet) is a Turkish polarity dictionary made up of 80.000 synsets (sets of synonymous words and expressions). Polarity dictionaries are corpora in which the entries are categorized into three groups: positive, neutral and negative. This resource is meant to be used for sentiment analysis, in which a text can be evaluated in terms of its judgements of positive or negative meaning. 

Detailed Description
============
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
