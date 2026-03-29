# 🚗 Aplicație Târg Auto

## 📌 Descriere

Aplicația „Târg Auto” este o aplicație de tip consolă realizată în limbajul C#, care permite gestionarea tranzacțiilor de vânzare-cumpărare a autovehiculelor.

Aplicația permite introducerea, salvarea și afișarea tranzacțiilor, precum și generarea unor rapoarte utile.

---

## 🎯 Funcționalități

* ➕ Adăugare tranzacție (vânzător, cumpărător, mașină, preț, dată)
* 📋 Afișare tranzacții
* 🔍 Căutare după cumpărător
* 📅 Afișare tranzacții dintr-o anumită zi
* 📊 Determinarea celei mai căutate mașini
* 💾 Salvare și citire din fișier text (persistență)

---

## 🧱 Structura aplicației

Aplicația este organizată pe baza principiilor Programării Orientate pe Obiecte:

### Clase principale:

* `Persoana` – reprezintă o persoană (vânzător / cumpărător)
* `Masina` – conține informații despre autovehicul
* `Tranzactie` – descrie o tranzacție

### Nivel de stocare:

* `IStocareData` – interfață pentru stocare
* `AdministrareTranzactiiMemorie` – stocare în memorie
* `AdministrareTranzactiiFisierText` – stocare în fișier text

### Factory:

* `StocareFactory` – decide tipul de stocare utilizat

---

## 💾 Persistența datelor

Datele sunt salvate într-un fișier text:

```text
tranzactii.txt
```

📍 Locație:

```text
bin/Debug/netX.X/tranzactii.txt
```

Datele sunt salvate în format:

```text
Vanzator;Cumparator;Firma;Model;An;Culoare;Optiuni;Pret;Data
```

## ⚙️ Tehnologii utilizate

* Limbaj: C#
* Paradigmă: Programare Orientată pe Obiecte
* I/O: Fișiere text (StreamWriter, StreamReader)
* Structuri de date: List, Dictionary

---

## 🧠 Concepte utilizate

* Clase și obiecte
* Interfețe (interface)
* Polimorfism
* Persistența datelor
* Lucrul cu fișiere text
* Structuri de control și colecții

## 👨‍🎓 Autor

Student: Marius Zaharia Andronic
Facultatea: Fiesc Calculatoare – dual


---
