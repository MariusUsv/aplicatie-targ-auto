# 🚗 Car Marketplace Management — Desktop Application (WPF)

Desktop application built with **C# and WPF (.NET)** for managing car marketplace transactions and client records.  
The project focuses on clean UI architecture, data synchronization, and structured application design.

---

## 🚀 Overview

The application provides a complete system for managing:
- Car sale transactions  
- Client records  
- Search and reporting functionalities  

It simulates a real-world desktop management tool, emphasizing **data consistency, UI responsiveness, and structured logic separation**.

---

## ✨ Core Features

### 🔹 Transaction Management (CRUD)
- Create, update, delete transactions  
- Automatic timestamp updates  
- Input validation and structured data handling  

### 🔹 Business Logic Validation
- Prevents multiple transactions for the same user in a single day  
- Real-time warning system (popup alerts)  

### 🔹 Client Management
- Separate module for managing client data  
- Real-time synchronization with UI  

### 🔹 Search & Filtering (LINQ)
- Instant filtering by seller name or car model  
- Date-based filtering using DatePicker  

### 🔹 UI/UX
- Dark Mode interface  
- Responsive layout (Grid + StackPanel)  
- Tab-based navigation (Transactions / Clients)  

---

## 🛠 Tech Stack

- **Language:** C#  
- **Framework:** WPF (.NET)  
- **UI:** XAML  
- **Data Binding:** ObservableCollection  
- **Querying:** LINQ  
- **Storage:** File-based persistence  

---

## 🧱 Architecture

Layered architecture with clear separation of concerns:
1. **Models Library** → domain entities (Transaction, Car, Person)  
2. **Data Layer** → file storage and data handling  
3. **WPF App** → UI + interaction logic  

---

## 🧠 Engineering Decisions

- **WPF over WinForms:** Chosen for advanced UI capabilities and native support for data binding.
- **ObservableCollection:** Used to ensure automatic UI updates without manual refresh logic.
- **LINQ for querying:** Enables clean and readable filtering logic directly on in-memory collections.
- **Layered architecture:** Separates UI, business logic, and data storage for maintainability and scalability.

---

## ⚙️ Key Concepts Implemented

- Data Binding with automatic UI updates  
- Event-driven programming (delegates, handlers)  
- Separation between UI and business logic  
- Structured data persistence  
- LINQ-based querying  

---

## ⚠️ Engineering Challenges

- Synchronizing UI with underlying data without performance issues  
- Preventing inconsistent state during multiple edits  
- Implementing business rules (one transaction per day per user) without blocking UI responsiveness  

**Solutions:**
- Data Binding with ObservableCollection  
- Centralized validation logic  
- Event-driven updates to avoid redundant UI refreshes  

---

## 🚧 Limitations & Future Improvements

**Current Limitations:**
- Local file storage (no database)
- Single-user application

**Future Improvements:**
- Database integration (SQL Server / Entity Framework)
- REST API integration for remote data access
- User authentication system

---

## 📌 Positioning

This project demonstrates solid understanding of **desktop application architecture, UI data binding, and business logic implementation**.

It is complemented by more advanced projects (e.g., Linko Pro), which extend these concepts into **real-time systems, backend architecture, and distributed communication**.

---
📫 **Contact:** [MariusUsv GitHub](https://github.com/MariusUsv)
