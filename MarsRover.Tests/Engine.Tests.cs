using MarsRover.Core;
using MarsRover.Core.Enums;
using MarsRover.Core.Models;
using MarsRover.Services.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Tests
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void Start_TrueInputs_ReturnSuccess()
        {
            EngineService engineService = new EngineService();

            RequestModel requestModel = new RequestModel()
            {
                MapRange = "55",
                Coordination = "12N",
                Commands = "LMLMLMLMM"
            };

            var checkedModel = Helper.CheckRequestModel(requestModel);
            if (checkedModel.Type == ResultTypes.Success)
            {
                Assert.AreEqual(ResultTypes.Success, engineService.Start(new VehicleRoute(requestModel)).Type);
            }
            else
            {
                Assert.AreEqual(ResultTypes.Error, checkedModel.Type);
            }
        }

        [TestMethod]
        public void Start_TrueInputs_ReturnFail()
        {
            EngineService engineService = new EngineService();

            RequestModel requestModel = new RequestModel()
            {
                MapRange = "55",
                Coordination = "12N",
                Commands = "MMMMMMMM"
            };

            var checkedModel = Helper.CheckRequestModel(requestModel);
            if (checkedModel.Type == ResultTypes.Success)
            {
                Assert.AreEqual(ResultTypes.Fail, engineService.Start(new VehicleRoute(requestModel)).Type);
            }
            else
            {
                Assert.AreEqual(ResultTypes.Error, checkedModel.Type);
            }
        }

        [TestMethod]
        public void Start_WrongInputs_ReturnError()
        {
            EngineService engineService = new EngineService();

            RequestModel requestModel = new RequestModel()
            {
                MapRange = "N5",
                Coordination = "12N",
                Commands = "LMLMLMLMM"
            };

            var checkedModel = Helper.CheckRequestModel(requestModel);
            if (checkedModel.Type == ResultTypes.Success)
            {
                Assert.AreEqual(ResultTypes.Success, engineService.Start(new VehicleRoute(requestModel)).Type);
            }
            else
            {
                Assert.AreEqual(ResultTypes.Error, checkedModel.Type);
            }
        }
    }
}
