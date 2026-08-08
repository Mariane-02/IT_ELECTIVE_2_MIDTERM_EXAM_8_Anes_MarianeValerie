using IT_ELECTIVE_2_MIDTERM_EXAM_8_Anes_MarianeValerie.Models;
using IT_ELECTIVE_2_MIDTERM_EXAM_8_Anes_MarianeValerie.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT_ELECTIVE_2_MIDTERM_EXAM_8_Anes_MarianeValerie.Controllers;

[Authorize]
public class AttendeeController : Controller
{
    private readonly AttendeeVisitRepository _repository;

    public AttendeeController(AttendeeVisitRepository repository) => _repository = repository;

    public IActionResult Index(string? search)
    {
        ViewBag.Search = search;
        return View(_repository.Search(search));
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(AttendeeVisit model)
    {
        if (!ModelState.IsValid) return View(model);

        _repository.Add(model);
        TempData["Message"] = "Attendee registered successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var attendee = _repository.GetById(id);
        return attendee == null ? NotFound() : View(attendee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(AttendeeVisit model)
    {
        if (!ModelState.IsValid) return View(model);

        _repository.Update(model);
        TempData["Message"] = "Attendee information updated.";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int id)
    {
        var attendee = _repository.GetById(id);
        return attendee == null ? NotFound() : View(attendee);
    }

    [HttpGet]
    public IActionResult CheckOut(int id)
    {
        var attendee = _repository.GetById(id);
        return attendee == null ? NotFound() : View(attendee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CheckOutConfirmed(int id)
    {
        _repository.CheckOut(id);
        TempData["Message"] = "Check-out recorded successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        _repository.Delete(id);
        TempData["Message"] = "Attendee deleted.";
        return RedirectToAction(nameof(Index));
    }
}
