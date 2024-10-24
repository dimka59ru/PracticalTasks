using PracticalTasks.Task1App.Models;
using PracticalTasks.Task1App.Phones;

var phone = new Phone("1234", 4321);
phone.AddSubscriber(new Subscriber("Иванов", "Иван", "Иванович", "12345"));

phone.Call(123);
phone.Call(1);
phone.Call(2);
phone.Call(3);
phone.Call(4);
phone.Call(5);
phone.Call("987654");

Console.WriteLine();
var phone3g = new Phone3G("1234", 4321);
phone3g.Call(1);

Console.WriteLine();

using (var cameraPhone = new CameraPhone3G("1234", 4321))
{
  cameraPhone.TakePhoto();
}  

Console.ReadLine();
