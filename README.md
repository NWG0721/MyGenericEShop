[![Persian](https://img.shields.io/badge/Persian-addf00)](#/persian-section)
[![English](https://img.shields.io/badge/English-8A2BE2)](#/english-section)

<a name="persian-section"></a>
## زبان فارسی
### پروژه Generic E-shop.
این پروژه یک نمونه **بک‌اند فروشگاهی ساده و جنریک** است که با زبان **C# خالص** پیاده‌سازی شده و هدف اصلی آن، نمایش نحوه‌ی طراحی صحیح ساختارهای **`CRUD`** با استفاده از **`Generic Programming`** می‌باشد.

در این پروژه سعی شده است:
- عملیات اصلی `CRUD` به صورت **قابل استفاده مجدد (`Reusable`)** طراحی شود
- وابستگی بین بخش‌های مختلف کد به حداقل برسد
- ساختار پروژه ساده، خوانا و قابل توسعه باشد

این پروژه به عنوان یک **نمونه آموزشی** طراحی شده و تمرکز اصلی آن بر:
- استفاده از **`Generic Classes` و `Interfaces`**
- تفکیک مسئولیت‌ها (`Separation of Concerns`)
- طراحی تمیز و قابل فهم کد

می‌باشد.

در نسخه فعلی:
- داده‌ها به صورت ساده و در حافظه مدیریت می‌شوند
- تمرکز روی منطق طراحی و ساختار کد است، نه پیاده‌سازی دیتابیس واقعی
- ## 📂 ساختار پروژه
```
+---MyGenericEShop.Core
|   +---Common
|   |   \---Results
|   +---Entities
|   +---Interfaces
|   |   \---Repositories
+---MyGenericEShop.DataAccessLayer
|   +---Repository
|   \---UnitOfWork
+---MyGenericEShop.ApplicationProgrammingInterface
```
## ▶️ فایل `Program.cs` (نقطه ورود)

این فایل در لایه `ApplicationProgrammingInterface` قرار دارد و نقطه شروع اجرای برنامه است و مسئول:
- مقداردهی اولیه برنامه
- ایجاد نمونه از کلاس‌های اصلی
- اجرای سناریوی نمونه فروشگاه
- اتصال به بانک/ها اطلاعاتی

### روند اجرا:
1. برنامه از متد `Main` شروع می‌شود
2. نمونه‌ای از `Repository` ساخته می‌شود
3. داده‌های تست ایجاد می‌شوند
4. متدهای اصلی فروشگاه فراخوانی می‌شوند
## 🧩‌ جداول یا موجودیت ها  (Domain Models)`Entities`

این بخش شامل موجودیت‌های اصلی دامنه (Domain Entities) پروژه می‌باشد.
هر `Entity` نمایانگر یک مفهوم واقعی در یک فروشگاه آنلاین است و صرفاً
مسئول نگهداری داده‌ها می‌باشد و هیچ منطق تجاری پیچیده‌ای در آن‌ها قرار ندارد.

این `Entities` مبنای طراحی جداول دیتابیس و عملیات `CRUD` در لایه `Data Access` هستند.
<br />
<br />

## لایه `Core`

### کلاس `BaseEntity`

این کلاس، پایه‌ی تمامی `Entity‌` های پروژه است و ویژگی‌های مشترک
بین تمام موجودیت‌ها را فراهم می‌کند.

**مسئولیت‌ها:**
- تعریف شناسه یکتا برای هر `Entity`
- جلوگیری از تکرار کد در سایر مدل‌ها

سایر `Entity‌` ها از این کلاس ارث‌بری می‌کنند.

---

### کلاس `Cart`
نمایانگر سبد خرید کاربر قبل از ثبت سفارش نهایی.

**وظایف:**
- نگهداری آیتم‌های انتخاب‌شده توسط کاربر
- اتصال سبد خرید به کاربر
---

### کلاس `CartItem`
نمایانگر یک آیتم داخل سبد خرید.

**ویژگی‌ها:**
- محصول انتخاب‌شده
- تعداد
- قیمت در زمان افزودن به سبد
---
### کلاس `Product`
نمایانگر یک محصول قابل فروش در فروشگاه.

**اطلاعات شامل:**
- نام محصول
- قیمت
- دسته‌بندی
- توضیحات

---

### کلاس `Category`
دسته‌بندی محصولات برای سازمان‌دهی بهتر فروشگاه.

---

### کلاس `CategoryType`
نوع یا سطح دسته‌بندی (برای پشتیبانی از ساختارهای متنوع دسته‌ها).

---

### کلاس `Order`
نمایانگر یک سفارش ثبت‌شده توسط کاربر.

**نکته مهم:**
سفارش پس از نهایی شدن سبد خرید ایجاد می‌شود.

---

### کلاس `OrderItem`
نمایانگر آیتم‌های داخل یک سفارش.

هر `Order` شامل یک یا چند `OrderItem` می‌باشد.

---

### کلاس `Payment`
اطلاعات مربوط به پرداخت سفارش.

---

### کلاس `Price`
مدیریت مقدار قیمت به صورت مجزا برای جلوگیری از تکرار
و افزایش انعطاف‌پذیری طراحی.

---

### کلاس `Review`
امکان ثبت نظر و امتیاز برای محصولات توسط کاربران.

---

### کلاس `User`
نمایانگر کاربر سیستم با اطلاعات هویتی و دسترسی‌ها.

---

### کلاس `Role`
تعریف نقش‌های مختلف کاربران (مانند `Admin، Customer`).

---

### کلاس `TelegramTokens`
نگهداری اطلاعات مربوط به اتصال ربات تلگرام به سیستم.

این `Entity` برای یکپارچه‌سازی سیستم با تلگرام در نظر گرفته شده است.

---

> تمامی `Entity‌` ها به گونه‌ای طراحی شده‌اند که مستقل از تکنولوژی دیتابیس بوده و قابلیت استفاده در هر نوع پیاده‌سازی `Data Access` را داشته باشند.

---
## لایه `Data Access`
## 🗄️ کلاس `<GenericRepository<T`

این کلاس یک پیاده‌سازی جنریک از الگوی `Repository` می‌باشد که
تمامی عملیات `CRUD` را برای `Entity` هایی که از `BaseEntity` ارث‌بری می‌کنند
فراهم می‌کند.

این `Repository` مستقل از نوع `Entity` بوده و برای تمامی جداول
پروژه قابل استفاده است.

### قسمت Generic Constraint

این Repository فقط برای Entityهایی قابل استفاده است که
از کلاس BaseEntity ارث‌بری کرده باشند.

این محدودیت به منظور:
- تضمین وجود شناسه یکتا (ID)
- پشتیبانی از Soft Delete (IsDelete)
طراحی شده است.
---
### قسمت Select Operations
- متد**SelectAll**
  - دریافت لیست Entityها با قابلیت فیلتر دینامیک
  - پشتیبانی از Soft Delete
  - پشتیبانی از CancellationToken

- متد **SelectByIdAsync**
  - دریافت یک Entity بر اساس شناسه
  - امکان دریافت داده‌های حذف‌شده (Soft Deleted)

### قسمت Insert Operations
- متد **InsertAsync**
  - افزودن یک Entity جدید
  - مدیریت لغو عملیات با CancellationToken
  - بازگرداندن نتیجه استاندارد عملیات

- متد **InsertManyAsync**
  - افزودن گروهی Entityها
  - مناسب برای عملیات Bulk

### قسمت Update Operations
- متد **UpdateAsync**
  - بروزرسانی Entity
  - بدون وابستگی به نوع Entity
    
### قسمت Delete Operations
این Repository از هر دو نوع حذف پشتیبانی می‌کند:
- متد **Soft Delete**
  - داده از دیتابیس حذف نمی‌شود
  - فقط فیلد IsDelete فعال می‌شود

- متد **Hard Delete**
  - حذف دائمی داده از دیتابیس
- DeleteAsync
- DeleteByIdAsync
- DeleteManyAsync

### قسمت Restore Operations
- متد **RestoreAsync**
  - بازیابی Entity حذف‌شده

- متد **RestoreManyAsync**
  - بازیابی گروهی Entityها

این قابلیت باعث می‌شود داده‌ها
به صورت ایمن و قابل مدیریت حذف شوند.


## 📊 کلاس OperationResult
``` این کلاس در آدرس زیر واقع شده است
+---MyGenericEShop.Core
|   +---Common
|   |   \---Results
``` 
تمامی عملیات Repository یک شیء استاندارد از نوع OperationResult
بازمی‌گردانند که شامل:
- وضعیت موفقیت
- پیام عملیات
- داده خروجی
- کد خطا
- زمان اجرا
می‌باشد.

> این Repository به گونه‌ای طراحی شده است که
> بدون تغییر در منطق اصلی،
> قابل استفاده با هر نوع Entity و دیتابیس باشد.
<a name="english-Section"></a>
## English Section

### Generic E-Shop Project

This project is a **simple and generic back-end store** implemented in **pure C#**.  
Its main goal is to demonstrate the correct design of **`CRUD` operations** using **`Generic Programming`** concepts.

The project is designed to:
- Implement reusable `CRUD` operations
- Minimize dependencies between different parts of the code
- Keep the project structure simple, readable, and maintainable

This project serves as an **educational example** focusing on:
- The use of **`Generic Classes` and `Interfaces`**
- **Separation of Concerns**
- Clean and understandable code design

In the current version:
- Data is managed in-memory for simplicity
- The focus is on design and structure, not on real database implementation

---

## 📂 Project Structure
```
+---MyGenericEShop.Core
| +---Common
| | ---Results
| +---Entities
| +---Interfaces
| | ---Repositories
+---MyGenericEShop.DataAccessLayer
| +---Repository
| ---UnitOfWork
+---MyGenericEShop.ApplicationProgrammingInterface
```
---

## ▶️ `Program.cs` (Entry Point)

This file, located in the `ApplicationProgrammingInterface` layer, is the starting point of the program and is responsible for:
- Initializing the application
- Creating instances of core classes
- Running sample store scenarios
- Connecting to data sources (if any)

### Execution Flow:
1. Program starts from the `Main` method
2. A repository instance is created
3. Test/sample data is generated
4. Main store methods are executed

---

## 🧩 Entities (Domain Models)

This section includes the **core domain entities** of the project.  
Each `Entity` represents a real-world concept in an online store and is solely responsible for **data storage**. No complex business logic is included in these classes.

These Entities serve as the foundation for database tables and CRUD operations in the `Data Access` layer.

---

## Core Layer

### `BaseEntity`

This class is the base for all project entities and provides common properties for all other entities.

**Responsibilities:**
- Define a unique identifier (ID) for each entity
- Avoid code duplication across entities

All other entities inherit from this class.

---

### `Cart`
Represents a user's shopping cart before finalizing an order.

**Responsibilities:**
- Store items selected by the user
- Link the cart to the user

---

### `CartItem`
Represents a single item in a cart.

**Properties:**
- Selected product
- Quantity
- Price at the time of addition

---

### `Product`
Represents a product available for sale.

**Information includes:**
- Product name
- Price
- Category
- Description

---

### `Category`
Organizes products into categories for better store management.

---

### `CategoryType`
Defines the type or level of a category (supports hierarchical or flexible categorization).

---

### `Order`
Represents an order placed by a user.

**Important:**  
An order is created after the shopping cart is finalized.

---

### `OrderItem`
Represents individual items within an order.

Each `Order` contains one or more `OrderItem`s.

---

### `Payment`
Stores payment information for an order.

---

### `Price`
Manages the price amount separately to prevent duplication and improve flexibility.

---

### `Review`
Allows users to leave ratings and reviews for products.

---

### `User`
Represents a system user with identity and access information.

---

### `Role`
Defines user roles, such as `Admin` or `Customer`.

---

### `TelegramTokens`
Stores information for integrating a Telegram bot with the system.

---

> All entities are designed to be database-agnostic and can be used with any `Data Access` implementation.

---

## Data Access Layer

### 🗄️ `GenericRepository<T>`

This class is a generic implementation of the **Repository pattern**, providing CRUD operations for any `Entity` that inherits from `BaseEntity`.

It is **independent of the entity type** and can be used for all tables in the project.

---

### Generic Constraint

This repository can only be used with entities that inherit from `BaseEntity`.  

This constraint ensures:
- Presence of a unique identifier (ID)
- Support for soft deletes (`IsDelete`)

---

### Select Operations

- **SelectAll**
  - Retrieves a list of entities with dynamic filtering
  - Supports soft delete
  - Supports `CancellationToken`

- **SelectByIdAsync**
  - Retrieves a single entity by ID
  - Can include soft-deleted entities

---

### Insert Operations

- **InsertAsync**
  - Adds a new entity
  - Handles operation cancellation with `CancellationToken`
  - Returns a standardized operation result

- **InsertManyAsync**
  - Adds multiple entities in bulk

---

### Update Operations

- **UpdateAsync**
  - Updates an entity without dependency on its type

---

### Delete Operations

Supports both types of deletion:

- **Soft Delete**
  - Entity is not removed from the database
  - `IsDelete` flag is set

- **Hard Delete**
  - Entity is permanently removed from the database

- Available methods:
  - DeleteAsync
  - DeleteByIdAsync
  - DeleteManyAsync

---

### Restore Operations

- **RestoreAsync**
  - Restores a soft-deleted entity

- **RestoreManyAsync**
  - Restores multiple soft-deleted entities

This ensures data is **safely managed and recoverable**.

---

## 📊 `OperationResult` Class

Location in project:

```
+---MyGenericEShop.Core
| +---Common
| | ---Results
```

All repository operations return a standardized `OperationResult` object containing:
- Success status
- Message
- Returned data
- Error/operation code
- Execution timestamp

> This repository is designed to be **usable with any entity and database** without changing the core business logic.












