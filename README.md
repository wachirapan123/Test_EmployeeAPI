# Employee API - ตัวอย่างโปรเจค

นี่คือโปรเจคทดสอบ API สำหรับจัดการพนักงาน เขียนด้วย ASP.NET Core ใช้ In-Memory Database

## วิธีรัน
1. ดาวน์โหลดไฟล์โปรเจคจาก GitHub  
   https://github.com/wachirapan123/employee-api-test

2. แตกไฟล์ (ถ้าเป็น .zip) หรือ clone ด้วย Git

3. เปิดโปรเจคใน **Visual Studio **  
   - เปิดไฟล์ `.sln` ของโปรเจค

4. รันโปรเจค  
   - กดปุ่ม **Run** (หรือปุ่ม F5)  
   - โปรแกรมจะเริ่มทำงาน และ API จะรันบน `http://localhost:5138`

## เปิด Postman → Import → เลือกไฟล์:  
   Postman/EmployeeAPI.postman_collection.json
   
## Endpoint
- GET /api/employees → ดึงข้อมูลพนักงานทั้งหมด
- GET /api/employees/{EmpNo} → ดึงข้อมูลพนักงานตามรหัส
- POST /api/employees → เพิ่มพนักงานใหม่
- PUT /api/employees/{EmpNo} → แก้ไขข้อมูลพนักงาน
- DELETE /api/employees/{EmpNo} → ลบพนักงาน
