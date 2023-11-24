using Lab5_MVC.Models;
using Lab5_MVC.Models.Entity;
using Lab5_MVC.Models.Entity.Enums;
using Lab5_MVC.Models.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab5_MVC.Controllers;

public class ScheduleController : Controller
{
    
    private readonly IScheduleService _scheduleService;
    private readonly IAudienceService _audienceService;
    private readonly IGroupService _groupService;
    private readonly ILessonService _lessonService;
    private readonly ITeacherService _teacherService;
    private readonly Lab5DbContext _lab5DbContext;

    public ScheduleController(IScheduleService scheduleService, IAudienceService audienceService, IGroupService groupService, ILessonService lessonService, ITeacherService teacherService, Lab5DbContext lab5DbContext)
    {
        _scheduleService = scheduleService;
        _audienceService = audienceService;
        _groupService = groupService;
        _lessonService = lessonService;
        _teacherService = teacherService;
        _lab5DbContext = lab5DbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var schedule = await _scheduleService.GetAllAsync(cancellationToken);
        return View(schedule);
    }
    
    public async Task<IActionResult> Create(CancellationToken cancellationToken)
    {
        var lessons = await _lessonService.GetAllAsync(cancellationToken);
        var groups = await _groupService.GetAllAsync(cancellationToken);
        var teachers = await _teacherService.GetAllAsync(cancellationToken);
        var audiences = await _audienceService.GetAllAsync(cancellationToken);
        
        ViewData["Lessons"] = lessons;
        ViewData["Groups"] = groups;
        ViewData["Teachers"] = teachers;
        ViewData["Audiences"] = audiences;
        return View();
    }
    
    public async Task<IActionResult> Save(Schedule schedule, CancellationToken cancellationToken)
    {
        var lessonIdInt = Convert.ToInt32(Request.Form["lessonId"]);
        var groupIdInt = Convert.ToInt32(Request.Form["groupId"]);
        var teacherIdInt = Convert.ToInt32(Request.Form["teacherId"]);
        var audienceIdInt = Convert.ToInt32(Request.Form["audienceId"]);
        
        var lesson = await _lessonService.GetByIdAsync(lessonIdInt, cancellationToken);
        var group = await _groupService.GetByIdAsync(groupIdInt, cancellationToken);
        var teacher = await _teacherService.GetByIdAsync(teacherIdInt, cancellationToken);
        var audience = await _audienceService.GetByIdAsync(audienceIdInt, cancellationToken);
        
        Days day = (Days)Enum.Parse(typeof(Days), Request.Form["Day"].ToString());

        schedule.Lesson = lesson;
        schedule.Group = group;
        schedule.Teacher = teacher;
        schedule.Audience = audience;
        schedule.Day = day.ToString(); 
        schedule.Week = int.Parse(Request.Form["Week"]); 
    
        await _scheduleService.AddToSchedule(schedule, cancellationToken);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
    {
        var schedule = await _scheduleService.GetByIdAsync(id, cancellationToken);

        var lessons = await _lessonService.GetAllAsync(cancellationToken);
        var groups = await _groupService.GetAllAsync(cancellationToken);
        var teachers = await _teacherService.GetAllAsync(cancellationToken);
        var audiences = await _audienceService.GetAllAsync(cancellationToken);
        
        ViewData["Lessons"] = lessons;
        ViewData["Groups"] = groups;
        ViewData["Teachers"] = teachers;
        ViewData["Audiences"] = audiences;
        return View(schedule);
    }

    [HttpPost]
    public async Task<IActionResult> SaveEdit(Schedule schedule, CancellationToken cancellationToken)
    {
        var lessonIdInt = Convert.ToInt32(Request.Form["lessonId"]);
        var groupIdInt = Convert.ToInt32(Request.Form["groupId"]);
        var teacherIdInt = Convert.ToInt32(Request.Form["teacherId"]);
        var audienceIdInt = Convert.ToInt32(Request.Form["audienceId"]);

        var lesson = await _lessonService.GetByIdAsync(lessonIdInt, cancellationToken);
        var group = await _groupService.GetByIdAsync(groupIdInt, cancellationToken);
        var teacher = await _teacherService.GetByIdAsync(teacherIdInt, cancellationToken);
        var audience = await _audienceService.GetByIdAsync(audienceIdInt, cancellationToken);
        
        Days day = (Days)Enum.Parse(typeof(Days), Request.Form["Day"].ToString());
        
        schedule.Lesson = lesson;
        schedule.Group = group;
        schedule.Teacher = teacher;
        schedule.Audience = audience;
        schedule.Day = day.ToString();
        schedule.Week = int.Parse(Request.Form["Week"]);

        await _scheduleService.EditSchedule(schedule, cancellationToken);
        
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _scheduleService.DeleteById(id, cancellationToken);
        return RedirectToAction("Index");
    }
}