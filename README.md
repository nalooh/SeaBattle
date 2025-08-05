# Sea Battle
Klasická hra Lodě (Sea Battle) je jednoduchá strategická hra pro dva hráče. Cílem hry je zničit všechny lodě soupeře dříve, než on zničí ty tvoje.

Pro spuštění hry pošlete POST požadavek na "/api/games" s následujícími vstupními parametry:
- Jméno hráče 1
- Jméno hráče 2
- Velikost hracího pole (mezi 10 a 20)

Pro každého hráče se náhodně umístí následující lodě libovolně svisle nebo podélně orientované, lodě se nesmí dotýkat žádnou stranou a ani rohem.
- 2 x
```
X
```
- 2 x
```
XX
```
- 1 x
```
XXX
```
- 1 x
```
 X
XXX
 X
```
- 1x
```
 X
XXXX
 X
```
   
Hra probíhá v jednotlivých tazích kdy se na server předávají následující POST požadavky na "/api/games/{id}/moves", kde {id} je ID hry.

- Pozice X
- Pozice Y

A server odpovídá stavy dle zásahu:

- Voda
- Zásah
- Potopena celé
- Výhra

Hráči se v jednotlivých tazích střídají v případě, že je odpověď voda, jinak pokračuje hráč, který právě táhl.

Hra končí ve chvíli, kdy jeden z hráčů nemá žádnou loď ani její část k dispozici.
