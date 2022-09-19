using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API_TEST
{
    public class Tests
    {
        // Global variable
        API_M3_V5.Controllers.ClientController client_controller = null!;
        API_M3_V5.Controllers.StaffController staff_controller = null!;
        API_M3_V5.Controllers.ServiceController service_controller = null!;
        API_M3_V5.Controllers.SupplierController supplier_controller = null!;
        OkObjectResult? response_expected;


        [SetUp]
        public void Setup()
        {
            client_controller = new API_M3_V5.Controllers.ClientController();
            staff_controller = new API_M3_V5.Controllers.StaffController();
            service_controller = new API_M3_V5.Controllers.ServiceController();
            supplier_controller = new API_M3_V5.Controllers.SupplierController();
        }

        #region Client Controller Test
        [Test]
        public void TestGetClients()
        {
            ActionResult<string> response = client_controller.GetClients();

            response_expected = response.Result as OkObjectResult;

            Assert.IsNotNull(response_expected);
            Assert.AreEqual(response_expected, response.Result);
        }

        [Test]
        public void TestInsertNewClient()
        {
            // Initialize required classes and objects
            //var controller = new API_M3_V5.Controllers.ClientController();
            API_M3_V5.Models_aux.Client_aux client_tester = new();

            client_tester.Username = "client_tester_by_nunity_1212";
            client_tester.FirstName = "client_tester_by_nunity_1212";
            client_tester.Surname = "client_tester_by_nunity_1212";
            client_tester.Nif = 319779405;
            client_tester.Phone = 319999405;
            client_tester.Email = "client_tester_by_nunity_1212@email.com";
            client_tester.Addressline = "nunity_street";
            client_tester.Zipcode = 01020304;
            client_tester.City = "nunity_city";
            client_tester.District = "nunity_state";
            client_tester.Country = "nunity_country";

            ActionResult<string> response = client_controller.AddClient(client_tester);
            response_expected = response.Result as OkObjectResult;

            Assert.IsNotNull(response_expected);
            Assert.AreEqual(response_expected, response.Result);
        }

        // Pretend to fail
        [Test]
        public void TestInsertNewClientWithoutParameter()
        {
            // Initialize required classes and objects
            //var controller = new API_M3_V5.Controllers.ClientController();
            API_M3_V5.Models_aux.Client_aux client_tester = new();

            client_tester.Username = "client_tester_by_nunity_2";
            client_tester.FirstName = "nunity_2";
            client_tester.Surname = "nunity_test_2";
            client_tester.Nif = 1102030405;
            client_tester.Phone = 0102030405;
            client_tester.Email = "nunity_2@email.com";
            client_tester.Addressline = "nunity_street";
            client_tester.Zipcode = 11020304;
            client_tester.City = "nunity_city";
            client_tester.Country = "nunity_country";

            ActionResult<string> response = client_controller.AddClient(client_tester);


            response_expected = response.Result as OkObjectResult;

            Assert.IsNotNull(response_expected);
            Assert.AreEqual(response_expected, response.Result);
        }

        //Pretend to fail
        [Test]
        public void TestInsertNewClientWithSameNif()
        {
            // Initialize required classes and objects
            //var controller = new API_M3_V5.Controllers.ClientController();
            API_M3_V5.Models_aux.Client_aux client_tester = new();

            client_tester.Username = "client_tester_by_nunity_0";
            client_tester.FirstName = "Entiy_test_6";
            client_tester.Surname = "nunity_test_1";
            client_tester.Nif = 54165489;
            client_tester.Phone = 310230405;
            client_tester.Email = "nunity_1@email.com";
            client_tester.Addressline = "nunity_street";
            client_tester.Zipcode = 01020304;
            client_tester.City = "nunity_city";
            client_tester.District = "nunity_state";
            client_tester.Country = "nunity_country";

            ActionResult<string> response = client_controller.AddClient(client_tester);
            response_expected = response.Result as OkObjectResult;

            Assert.IsNotNull(response_expected);
            Assert.AreEqual(response_expected, response.Result);
        }

        [Test]
        public void TestUpdateClient()
        {
            // Initialize required classes and objects
            var controller = new API_M3_V5.Controllers.ClientController();
            API_M3_V5.Models_aux.Client_aux client_tester = new();

            client_tester.ClientId = 1020;
            client_tester.Username = "client_tester_by_nunity_up_9";
            client_tester.FirstName = "nunity_up_9";
            client_tester.Surname = "nunity_test_up_9";
            client_tester.Nif = 333030405;
            client_tester.Phone = 333030405;
            client_tester.Email = "nunity_up@email.com_9";
            client_tester.Addressline = "nunity_street";
            client_tester.Zipcode = 01020304;
            client_tester.City = "nunity_city";
            client_tester.District = "nunity_state";
            client_tester.Country = "nunity_country";

            ActionResult<string> response = client_controller.UpClient(client_tester);
            response_expected = response.Result as OkObjectResult;

            Assert.IsNotNull(response_expected);
            Assert.AreEqual(response_expected, response.Result);
        }
        #endregion

        #region Staff Controller Test
        [Test]
        public void TestGetStaff()
        {
            ActionResult<string> response = staff_controller.GetEmployees();

            response_expected = response.Result as OkObjectResult;

            Assert.IsNotNull(response_expected);
            Assert.AreEqual(response_expected, response.Result);
        }

        [Test]
        public void TestUpdateEmployee()
        {
            API_M3_V5.Models_aux.Staff_aux staff_tester = new();

            staff_tester.EmployeeId = 497;
            staff_tester.JobTitle = "staff_tester_by_nunity_up_33";
            staff_tester.Username = "staff_tester_by_nunity_up_33";
            staff_tester.FirstName = "nunity_up_22";
            staff_tester.Surname = "nunity_test_up_9";
            staff_tester.Nif = 333030805;
            staff_tester.Phone = 333550405;
            staff_tester.Email = "nunity_up@email.com_22";
            staff_tester.Addressline = "nunity_street";
            staff_tester.Zipcode = 01020304;
            staff_tester.City = "nunity_city";
            staff_tester.District = "nunity_state";
            staff_tester.Country = "nunity_country";

            ActionResult<string> response = staff_controller.UpEmployee(staff_tester);
            response_expected = response.Result as OkObjectResult;

            Assert.IsNotNull(response_expected);
            Assert.AreEqual(response_expected, response.Result);
        }
        #endregion

        #region Business Rule Tests
        [Test]
        public void TestGetServices()
        {
            ActionResult<string> response = service_controller.GetServices();

            response_expected = response.Result as OkObjectResult;

            Assert.IsNotNull(response_expected);
            Assert.AreEqual(response_expected, response.Result);
        }

        [Test]
        public void TestRegisterServiceAndManageStates()
        {
            API_M3_V5.Models_aux.Service_Aux service_example = new();
            DateTime date = System.DateTime.Now;

            service_example.TypeId = 1;
            service_example.ClientId = 10;
            service_example.StartDate = date;
            service_example.EndDate = date;
            service_example.Status = 0;
            service_example.State = "empty";
            service_example.Observations = "Reparação Equipamento Test_Nunity 7";

            ActionResult<string> response = service_controller.AddService(service_example);
            
            if(response.Result != null)
            {
                service_example.ServiceId = Convert.ToInt32(API_M3_V5.Models_aux.Service_Aux.Get_Service_Id_Aux(service_example.ClientId, service_example.StartDate, service_example.Observations));

                ActionResult<string> response_1 = service_controller.UpdateServiceState((service_example.ServiceId).ToString(), "3", "to_budget");

                if(response_1.Result != null)
                {
                    ActionResult<string> response_2 = service_controller.UpdateServiceState((service_example.ServiceId).ToString(), "3", "to_budget_approval");

                    if(response_2.Result != null)
                    {
                        ActionResult<string> response_3 = service_controller.UpdateServiceState((service_example.ServiceId).ToString(), "3", "to_execute");

                        if(response_3.Result != null)
                        {
                            ActionResult<string> response_4 = service_controller.UpdateServiceState((service_example.ServiceId).ToString(), "3", "waiting_payment");

                            if(response_4.Result != null)
                            {
                                ActionResult<string> response_5 = service_controller.UpdateServiceState((service_example.ServiceId).ToString(), "3", "to_pickup");
                                response_expected = response_5.Result as OkObjectResult;
                                Assert.IsNotNull(response_expected);
                                Assert.AreEqual(response_expected, response_5.Result);
                            }
                        }
                    }
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.Fail();
            }
        }

        #endregion

        #region Test Get Services By Options
        [Test]
        public void TestGetServicesByClient()
        {
            ActionResult<string> response = service_controller.GetServices_by_client("agerhard");

            response_expected = response.Result as OkObjectResult;

            Assert.IsNotNull(response_expected);
            Assert.AreEqual(response_expected, response.Result);
        }

        [Test]
        public void TestGetServicesByState()
        {
            ActionResult<string> response = service_controller.GetServices_by_state("done");

            response_expected = response.Result as OkObjectResult;

            Assert.IsNotNull(response_expected);
            Assert.AreEqual(response_expected, response.Result);
        }

        [Test]
        public void TestGetServicesHistory()
        {
            ActionResult<string> response = service_controller.GetServices_history("1");

            response_expected = response.Result as OkObjectResult;

            Assert.IsNotNull(response_expected);
            Assert.AreEqual(response_expected, response.Result);
        }

        [Test]
        public void TestGetServicesOrders()
        {
            ActionResult<string> response = service_controller.GetServices_orders("155");

            response_expected = response.Result as OkObjectResult;

            Assert.IsNotNull(response_expected);
            Assert.AreEqual(response_expected, response.Result);
        }

        [Test]
        public void TestGetServiceBudget()
        {
            ActionResult<string> response = service_controller.GetServices_budget("155");

            response_expected = response.Result as OkObjectResult;

            Assert.IsNotNull(response_expected);
            Assert.AreEqual(response_expected, response.Result);
        }
        #endregion

        #region Supplier
        [Test]
        public void TestGetSuppliers()
        {
            ActionResult<string> response = supplier_controller.GetSuppliers();

            response_expected = response.Result as OkObjectResult;

            Assert.IsNotNull(response_expected);
            Assert.AreEqual(response_expected, response.Result);
        }
        #endregion
    }
}