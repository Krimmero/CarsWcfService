using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CarsWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        Car getCar(int id);

        [OperationContract]
        Car addCar(Car composite);

        [OperationContract]

        List<Car> getCars();

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Car
    {
        private string _brand;
        private string _model;
        private Colors _color;
        private float _engine;
        private int _id;

        [DataMember]
        public Colors color
        {
            get { return _color; }
            set { _color = value; }
        }


        [DataMember]
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        [DataMember]
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        [DataMember]
        public float Engine
        {
            get { return _engine; }
            set { _engine = value; }
        }

        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

     
    }

    [DataContract]
    public enum Colors
    {
        [EnumMember]
        Red,
        [EnumMember]
        Blue,
        [EnumMember]
        Black
    }
}
