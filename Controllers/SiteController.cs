using ADO.NET_.NET_CORE.Models;
using ADO.NET_.NET_CORE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADO.NET_.NET_CORE.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            StudentViewModel svm = new StudentViewModel();
            List<Student> student = svm.GetAllStudents();

            return View(student);
        }
        public IActionResult StudentInfo(int studentId=0)
        {

            Student student = new Student();
            if(studentId == 0)
            {
                student.StudentId = 0;

            }
            else

            {
                StudentViewModel svm = new StudentViewModel();
                student = svm.GetStudentByStudentId(studentId);
            }

            return View(student);

        }
        [HttpPost]
        public IActionResult StudentInfo(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentViewModel svm = new StudentViewModel();
                if (student.StudentId == 0)
                {
                    svm.AddStudent(student);
                }
                else
                {
                    svm.UpdateStudent(student);
                }
                return RedirectToAction("Index", "Site");
            }
           
            return View();

        }
        public IActionResult DeleteStudent(int studentId = 0)
        {
            StudentViewModel svm = new StudentViewModel();
            svm.DeleteStudent(studentId);

            return RedirectToAction("Index", "Site");
        }
    }
}
