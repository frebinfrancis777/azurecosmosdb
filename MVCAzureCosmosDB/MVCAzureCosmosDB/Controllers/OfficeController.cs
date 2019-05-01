using LinqKit;
using MVCAzureCosmosDB.DB;
using MVCAzureCosmosDB.Models;
using MVCAzureCosmosDB.Models.ViewModels;
using MVCAzureCosmosDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCAzureCosmosDB.Controllers
{
    [Authorize]
    public class OfficeController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public async Task<ActionResult> Index(string firstname, string lastname, string state)
        {
            var offices = await DocumentDBRepository<OfficeDetails>.GetItemsAsync(x => true);

            ViewBag.firstname = firstname;
            ViewBag.lastname = lastname;
            ViewBag.state = state;

            var list = new List<OfficeListViewModel>();
            if (offices != null && offices.Any())
            {
                foreach (var office in offices)
                {
                    if (office.RecruitingContacts != null && office.RecruitingContacts.Any())
                    {
                        foreach (var contact in office.RecruitingContacts)
                        {
                            list.Add(new OfficeListViewModel()
                            {
                                State = office.State,
                                Firstname = contact.FirstName,
                                Lastname = contact.LastName,
                                Phone = contact.Phone,
                                PersonID = contact.PersonID
                            });
                        }
                    }
                }
            }

            var predicate = GenerateWhereFilter(firstname, lastname, state);
            var filteredList = list.Where(predicate);

            return View(filteredList);
        }

        [HttpGet]
        public async Task<ActionResult> Create(string id)
        {
            var viewModel = new CreateOfficeViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                Office office = await DocumentDBRepository<Office>.GetItemAsync(id);
                if (office != null)
                {
                    viewModel = new CreateOfficeViewModel()
                    {
                        Concentration = office.Concentration,
                        Degree = office.Degree,
                        Degreeconcentration = office.Degreeconcentration,
                        Description = office.Description,
                        Firstname = office.Firstname,
                        id = id,
                        Lastname = office.Lastname,
                        Major = office.Major,
                        Middlename = office.Middlename,
                        School = office.School,
                        Schoolyear = office.Schoolyear,
                        State = office.State,
                    };
                }
            }
            else
            {
                viewModel.State = Convert.ToString(this.Session["state"]);
            }

            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(CreateOfficeViewModel viewModel)
        {
            var response = new ResponseViewModel();

            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(viewModel.id))
                    {
                        await DocumentDBRepository<Office>.UpdateItemAsync(viewModel.id,
                           new Office()
                           {
                               Id = viewModel.id,
                               Concentration = viewModel.Concentration,
                               Degree = viewModel.Degree,
                               Degreeconcentration = viewModel.Degreeconcentration,
                               Description = viewModel.Description,
                               Firstname = viewModel.Firstname,
                               Lastname = viewModel.Lastname,
                               Major = viewModel.Major,
                               Middlename = viewModel.Middlename,
                               School = viewModel.School,
                               Schoolyear = viewModel.Schoolyear,
                               State = viewModel.State
                           });

                        response.IsSucess = true;
                        response.Message = "Record updated successfully.";
                    }
                    else
                    {
                        await DocumentDBRepository<Office>.CreateItemAsync(
                          new Office()
                          {
                              Concentration = viewModel.Concentration,
                              Degree = viewModel.Degree,
                              Degreeconcentration = viewModel.Degreeconcentration,
                              Description = viewModel.Description,
                              Firstname = viewModel.Firstname,
                              Lastname = viewModel.Lastname,
                              Major = viewModel.Major,
                              Middlename = viewModel.Middlename,
                              School = viewModel.School,
                              Schoolyear = viewModel.Schoolyear,
                              State = viewModel.State
                          });

                        response.IsSucess = true;
                        response.Message = "Record inserted successfully.";
                    }
                }
                else
                {
                    response.IsSucess = false;
                    response.Message = "Record validation failed.";
                }
            }
            catch (Exception)
            {
                response.IsSucess = false;
                response.Message = "Process failed...";
            }

            TempData["response"] = response;

            if (response.IsSucess)
            {
                if (viewModel.AddMoreRecord)
                {
                    this.Session["state"] = viewModel.State;
                    return RedirectToAction("Create", "Office", null);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult CreateBulk()
        {
            var list = new List<CreateStateContactViewModel>();
            list.Add(new CreateStateContactViewModel()
            {
                States = new SelectList(StateAPIService.GetStates())
            });

            return this.View(list);
        }

        [HttpPost]
        [ActionName("CreateBulk")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateBulk(List<CreateStateContactViewModel> viewModel)
        {
            var response = new ResponseViewModel();

            try
            {
                if (ModelState.IsValid && viewModel != null && viewModel.Any())
                {
                    var groupByState = viewModel.GroupBy(x => x.State).ToList();

                    foreach (var state in groupByState)
                    {
                        await DocumentDBRepository<OfficeDetails>.CreateItemAsync(
                        new OfficeDetails()
                        {
                            State = state.Key,
                            RecruitingContacts = state.Select(x => new Person()
                            {
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                Phone = x.Phone
                            }).ToList()
                        });
                    }

                    response.IsSucess = true;
                    response.Message = "Record inserted successfully.";
                }
                else
                {
                    response.IsSucess = false;
                    response.Message = "Record validation failed.";
                }
            }
            catch (Exception)
            {
                response.IsSucess = false;
                response.Message = "Process failed...";
            }

            TempData["response"] = response;

            if (response.IsSucess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            ResponseViewModel response = new ResponseViewModel();

            try
            {
                await DocumentDBRepository<Office>.DeleteItemAsync(id);

                response.IsSucess = true;
                response.Message = "Record deleted successfully.";
            }
            catch (Exception)
            {
                response.IsSucess = false;
                response.Message = "Record deletion failed.";
            }

            TempData["response"] = response;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> EditPerson(Guid id)
        {
            var viewModel = new EditOfficeContactViewModel();

            var offices = await DocumentDBRepository<OfficeDetails>.
                               GetItemsAsync(x => x.RecruitingContacts.Any(y => y.PersonID == id));

            if (offices != null && offices.Any())
            {
                foreach (var office in offices)
                {
                    var person = office.RecruitingContacts.FirstOrDefault(x => x.PersonID == id);
                    if (person != null)
                    {
                        viewModel.PrevFirstName = person.FirstName;
                        viewModel.FirstName = person.FirstName;
                        viewModel.LastName = person.LastName;
                        viewModel.Phone = person.Phone;

                        break;
                    }
                }
            }

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditPerson(EditOfficeContactViewModel viewModel)
        {
            var response = new ResponseViewModel();

            try
            {
                var offices = await DocumentDBRepository<OfficeDetails>.
                               GetItemsAsync(x => x.RecruitingContacts.Any(y => y.FirstName.ToLower() == viewModel.PrevFirstName.ToLower()));

                if (offices != null && offices.Any())
                {
                    foreach (var office in offices)
                    {
                        office.RecruitingContacts
                            .Where(x => x.FirstName.Equals(viewModel.PrevFirstName, StringComparison.OrdinalIgnoreCase))
                            .ToList()
                            .ForEach((person) =>
                            {
                                person.FirstName = viewModel.FirstName;
                                person.LastName = viewModel.LastName;
                                person.Phone = viewModel.Phone;
                            });

                        await DocumentDBRepository<OfficeDetails>.UpdateItemAsync(office.Id, office);
                    }
                }

                response.IsSucess = true;
                response.Message = "Record updated successfully.";
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Process failed...";
            }

            TempData["response"] = response;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> DeletePerson(Guid id)
        {
            var response = new ResponseViewModel();

            try
            {
                var offices = await DocumentDBRepository<OfficeDetails>.
                               GetItemsAsync(x => x.RecruitingContacts.Any(y => y.PersonID == id));

                if (offices != null && offices.Any())
                {
                    foreach (var office in offices)
                    {
                        office.RecruitingContacts.RemoveAll(x => x.PersonID == id);
                        await DocumentDBRepository<OfficeDetails>.UpdateItemAsync(office.Id, office);
                    }
                }

                response.IsSucess = true;
                response.Message = "Record deleted successfully.";
            }
            catch (Exception)
            {
                response.IsSucess = false;
                response.Message = "Process failed...";
            }

            TempData["response"] = response;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            Response.Cookies.Clear();
            return RedirectToAction("Index", "Home");
        }

        private static ExpressionStarter<OfficeListViewModel> GenerateWhereFilter(
           string firstname,
           string lastname,
           string state)
        {
            ExpressionStarter<OfficeListViewModel> predicate = PredicateBuilder.New<OfficeListViewModel>(true);
            if (!string.IsNullOrEmpty(firstname))
            {
                predicate = predicate.And(x => x.Firstname.ToLower() == firstname.ToLower());
            }

            if (!string.IsNullOrEmpty(lastname))
            {
                predicate = predicate.And(x => x.Lastname.ToLower() == lastname.ToLower());
            }

            if (!string.IsNullOrEmpty(state))
            {
                predicate = predicate.And(x => x.State.ToLower() == state.ToLower());
            }

            return predicate;
        }
    }
}