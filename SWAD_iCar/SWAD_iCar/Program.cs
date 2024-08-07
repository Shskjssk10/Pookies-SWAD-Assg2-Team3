

void Caden_Part()
{
    // Test Data
    DateTime dateTime = DateTime.Now;
    DateTime birthday = new DateTime(2006, 8, 10);
    Card card1 = new Card("Debit", 10008000, 111, dateTime);
    CarOwner carOwner1 = new CarOwner(1, "Caden", "Shskjssk10", card1, birthday, 84469588);
    List<string> photos = new List<string>();
    photos.Add("image1");
    Dictionary<int ,string> reviews = new Dictionary<int ,string>();
    reviews.Add(1, "this sucks");
    carOwner1.linkCarToCarOwner(new Car("Make1", "Model1", 2006, 190, photos, false, reviews, "LicensePlate1", 20));

    // Main Program

    UI_manageCar UI_manageCar =  new UI_manageCar();
    List<Car> cars = UI_manageCar.getRegisteredCars(carOwner1);

    Car selectedCar = UI_manageCar.selectCar(cars);
    string option = UI_manageCar.modificationAction();
    List<Timeslot> selectedTimeslots = new List<Timeslot>();
    List<Timeslot> registeredTimeslots = UI_manageCar.getTimeSlots(selectedCar);
    switch (option)
    {
        case "Modify Timeslots":
            selectedTimeslots = UI_manageCar.selectTimeSlots(registeredTimeslots);
            break;
        case "Add Timeslots":
            UI_manageCar.inputNewTimeslotsDateTill();
            break;
        case "Remove Timeslots":
            selectedTimeslots = UI_manageCar.selectTimeSlots(registeredTimeslots);
            break;
    }
}

Caden_Part();

