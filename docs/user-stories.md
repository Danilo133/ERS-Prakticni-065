# Корисничке приче

<!-- Самостално написати шест прича према додељеној спецификацији. -->
<!-- За сваку причу навести улогу, могућност, корист, F-ознаку и >= 2 критеријума прихватања. -->

## US-01: Dodavanje individualnog casa (F1)

Kao administrator skole plivanja,
zelim da dodam novi zapis tipa „Individualni cas“ sa nazivom, opisom, imenom instruktora, imenom polaznika i trajanjem, kako bih evidentirao zakazani individualni trening i dobio njegov jedinstveni identifikator.

Kriterijumi prihvatanja:
- Kada se unesu ispravan naziv, opis, ime instruktor, ime polaznika i trajanje izmedju 20-90 minuta, sistem kreira zapis sa pocetnim statusom „Upisan“ i prikazuje dodeljeni jedinstevni identifikator (ID).
- Kada je naziv, opis ili ime instruktora prazno, ili trajanje van opsega 20-90 minuta(npr. 15 ili 100 minuta), sistem odbija unos, prikazuje poruku o gresci i ne cuva zapis

## US-02 Dodavanje grunog casa (F2)

Kao administrator skole plivanja,
zelim da dodam novi zapis tipa „Grupni cas“ sa nazivom, opisom, brojem polaznika, spiskom imena polaznika i trajanjem,
kako bih evidentirao grupni trening i dobio njegov jedinstveni identifikator.

Kriterijumi prihvatanja:
- Kada se unesu ispravan naziv, opis, broj polaznika izmedju 2 i 15 , odgovarajuci broj imena polanzika i trajanje izmedju 20 i 90 minuta, sistem kreira zapis i prikazuje dodeljeni identifikator (ID).
- Kada je broj polaznika manji od 2 ili veci od 15(npr. 1 ili 16), ili se broj unetih imena ne poklapa sa zadatim brojem polaznika, sistem odbija unos bez delimicnog upisa podataka.

## US-03 Pregled svih zapisa i poseta po polazniku (F3)

Kao koordinator nastave,
zelim da prikazem sve evidentirane casove u sazetom ili detaljnom formatu, kao i statistiku poseta po polazniku,
kako bih imao jasan uvid u sve treninge i redovnost polaznika

Kriterijumi prihvatanja:
- Kada postoje evidentirani zapisi, sistem prikazuje tip casa, identifikator, naziv i status(u sazetom prikazu), odnosno i ime instruktora i broj polaznika (u detaljnom prikazu), uz pogled poseta po svakom polazniku.
- Kada u sistemu nema evidentiranih zapsia, sistem prikazuje odgovarajucu informativnu poruku da lista zapisa ne sadrzi stavke.

## US-04 Pretraga zapisa po imenu polaznika (F4)

Kao administrator skole plivanja
zelim da pretrazim evidentirane zapise prema imenu polaznika bez obzira na velika i mala slova,
kako bih brzo pronasao sve casove na kojima odredjeni polaznik ucestvuje.

Kriterijumi prihvatanja:
- Kada se unese deo ili celo ime polaznika (npr „marko“ za upisanog „Marko Petrovic“), sistem vraca sve odgovarajuce zapise bez obzira na velicinu slova.
-Kada nijedan zapis ne sadrzi trazeno ime polaznika, sistem prikazuje odgovarajucu poruku da nema pronadjenih rezulatata.

## US-05 Evidentirarnje pristustva korisnika (F5)
Kao instruktor plivanja,
zelim da evidentiram prisustvo upisanog polaznika na odredjenom casu pomocu identifikatora casa i imena polaznika,
kako bih azurirao status obrade i evidenciju dolazaka.

Kriterijumi prihvatanja:
- Kada postoji cas sa zadatim identifikatorom i navedeni polaznik  je upisan na taj cas, sistem belezi prisustvo polaznika i azurira status casa.
-Kad je proseledjen nepostojeci identifikator casa ili polaznik koji nije upisan na taj cas, operacija vraca rezultat neuspeha bez promene stanja.

## US-06 Opracdanje odsustva polaznika (F6)

Kao administrator skole plivanja 
zelim da opravdam odsustvo polaznika na casu na kom nije bio prisutan,
kako bih uredno vodio evidenciju opravdanih izostanaka.

Kriterijumi prihvatanja:
- Kada je polaznik upisan na cas i prethodno nije evidentiran kao prisutan, sistem uspesno belezi opravdano odsustvo i azurira status.
- Kada je polaznik vec evidentiran kao prisutan na tom casu (ili cas/polaznik ne postoji), sistem odbija operaciju kao nedozvoljenu bez promene postojeceg stanja.
