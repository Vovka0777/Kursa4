using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleAppКУРСОВАЯ
{
    class Actions
    {
        private List<Animal> animals;
        private List<Owner> owners;
        private List<Veterinarian> veterinarians;
        private List<Appointment> appointments;

        public Actions() { }
        public Actions(List<Animal> animalsList, List<Owner> ownersList, List<Veterinarian> veterinariansList, List<Appointment> appointmentsList)
        {
            animals = animalsList;
            owners = ownersList;
            veterinarians = veterinariansList;
            appointments = appointmentsList;
        }

        public void AddAnimal()
        {
            Console.Write("Введите имя питомца: ");
            string name = Console.ReadLine();
            Console.Write("Введите вид питомца: ");
            string species = Console.ReadLine();
            Console.Write("Введите породу питомца: ");
            string breed = Console.ReadLine();
            Console.Write("Введите возраст питомца: ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age < 0)
            {
                Console.WriteLine("Некорректный возраст.");
                return;
            }
            Console.Write("Введите ФИО владельца: ");
            string ownerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(species) || string.IsNullOrWhiteSpace(breed) || string.IsNullOrWhiteSpace(ownerName))
            {
                Console.WriteLine("Все поля должны быть заполнены.");
                return;
            }

            Owner owner = owners.FirstOrDefault(o => o.FioOwner.Equals(ownerName, StringComparison.OrdinalIgnoreCase));
            if (owner == null)
            {
                Console.WriteLine($"Владелец с ФИО '{ownerName}' не найден. Пожалуйста, сначала добавьте владельца.");
                return;
            }

            int nextAnimalId = animals.Count > 0 ? animals.Last().IdAnimal + 1 : 1;
            Animal newAnimal = new Animal(nextAnimalId, name, species, breed, age, owner);
            animals.Add(newAnimal);
            owner.Animals.Add(newAnimal);
            Console.WriteLine($"Питомец '{name}' успешно добавлен.");
        }

        public void AddOwner()
        {
            Console.Write("Введите ФИО владельца: ");
            string fioOwner = Console.ReadLine();
            Console.Write("Введите телефон владельца: ");
            string phone = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fioOwner) || string.IsNullOrWhiteSpace(phone))
            {
                Console.WriteLine("Все поля должны быть заполнены.");
                return;
            }

            int nextOwnerId = owners.Count > 0 ? owners.Last().IdOwner + 1 : 1;
            Owner newOwner = new Owner(nextOwnerId, fioOwner, phone);
            owners.Add(newOwner);
            Console.WriteLine($"Владелец '{fioOwner}' успешно добавлен.");
        }

        public void AddVeterinarian()
        {
            Console.Write("Введите ФИО ветеринара: ");
            string fioVeter = Console.ReadLine();
            Console.Write("Введите специализацию ветеринара: ");
            string specialisation = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fioVeter) || string.IsNullOrWhiteSpace(specialisation))
            {
                Console.WriteLine("Все поля должны быть заполнены.");
                return;
            }

            int nextVeterinarianId = veterinarians.Count > 0 ? veterinarians.Last().IdVeter + 1 : 1;
            Veterinarian newVeterinarian = new Veterinarian(nextVeterinarianId, fioVeter, specialisation);
            veterinarians.Add(newVeterinarian);
            Console.WriteLine($"Ветеринар '{fioVeter}' успешно добавлен.");
        }

        public void AddAppointment()
        {
            Console.Write("Введите имя питомца: ");
            string animalName = Console.ReadLine();
            Console.Write("Введите ФИО ветеринара: ");
            string nameVeter = Console.ReadLine();
            Console.Write("Введите дату приема (дд.мм.гггг): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime data))
            {
                Console.WriteLine("Некорректный формат даты.");
                return;
            }
            Console.Write("Введите диагноз: ");
            string diagnosis = Console.ReadLine();
            Console.Write("Введите назначенное лечение: ");
            string medication = Console.ReadLine();
            Console.Write("Введите стоимость приема: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal cost) || cost < 0)
            {
                Console.WriteLine("Некорректная стоимость.");
                return;
            }

            if (string.IsNullOrWhiteSpace(animalName) || string.IsNullOrWhiteSpace(nameVeter) || string.IsNullOrWhiteSpace(diagnosis) || string.IsNullOrWhiteSpace(medication))
            {
                Console.WriteLine("Все поля должны быть заполнены.");
                return;
            }

            Animal animal = animals.FirstOrDefault(a => a.Name.Equals(animalName, StringComparison.OrdinalIgnoreCase));
            Veterinarian veterinarian = veterinarians.FirstOrDefault(v => v.FioVeter.Equals(nameVeter, StringComparison.OrdinalIgnoreCase));

            if (animal == null)
            {
                Console.WriteLine($"Питомец с именем '{animalName}' не найден.");
                return;
            }
            if (veterinarian == null)
            {
                Console.WriteLine($"Ветеринар с ФИО '{nameVeter}' не найден.");
                return;
            }

            int nextAppointmentId = appointments.Count > 0 ? appointments.Last().IdAppointment + 1 : 1;
            Appointment newAppointment = new Appointment(nextAppointmentId, animal, veterinarian, data, diagnosis, medication, cost);
            appointments.Add(newAppointment);
            veterinarian.HistoryAppointments.Add(newAppointment);
            Console.WriteLine($"Прием для питомца '{animalName}' у ветеринара '{nameVeter}' успешно назначен.");
        }

        public void PrintAnimalDetails()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine("Нет зарегистрированных животных.");
                return;
            }
            Console.WriteLine("--- Сведения о пациентах ---");
            foreach (var pet in animals)
            {
                Console.WriteLine($"- ID: {pet.IdAnimal}, Кличка: {pet.Name}, Вид: {pet.Species}, Порода: {pet.Breed}, Возраст: {pet.Age}, Владелец: {pet.Owner.FioOwner}");
            }
        }

        public void PrintOwnerDetails()
        {
            if (owners.Count == 0)
            {
                Console.WriteLine("Нет зарегистрированных владельцев.");
                return;
            }
            Console.WriteLine("--- Сведения о владельцах ---");
            foreach (var owner in owners)
            {
                Console.WriteLine($"- ID: {owner.IdOwner}, ФИО: {owner.FioOwner}, Телефон: {owner.Phone}, Питомцы: {string.Join(", ", owner.Animals.Select(a => a.Name))}");
            }
        }

        public void PrintVeterinarianDetails()
        {
            if (veterinarians.Count == 0)
            {
                Console.WriteLine("Нет зарегистрированных ветеринаров.");
                return;
            }
            Console.WriteLine("--- Сведения о ветеринарах ---");
            foreach (var veter in veterinarians)
            {
                Console.WriteLine($"- ID: {veter.IdVeter}, ФИО: {veter.FioVeter}, Специализация: {veter.Specialisation}");
                if (veter.HistoryAppointments.Any())
                {
                    Console.WriteLine($"  История приемов ({veter.HistoryAppointments.Count}):");
                    foreach (var appointment in veter.HistoryAppointments)
                    {
                        Console.WriteLine($"    - Дата: {appointment.Data.ToShortDateString()}, Питомец: {appointment.Animal.Name}, Диагноз: {appointment.Diagnosis}");
                    }
                }
                else
                {
                    Console.WriteLine("  История приемов отсутствует.");
                }
            }
        }

        public void PrintAppointmentDetails()
        {
            if (appointments.Count == 0)
            {
                Console.WriteLine("Нет зарегистрированных приемов.");
                return;
            }
            Console.WriteLine("--- Сведения о приёмах ---");
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"- ID: {appointment.IdAppointment}, Питомец: {appointment.Animal.Name}, Ветеринар: {appointment.Veterinarian.FioVeter}, Дата: {appointment.Data.ToShortDateString()}, Диагноз: {appointment.Diagnosis}, Лечение: {appointment.Medication}, Стоимость: {appointment.Cost}");
            }
        }

        public void GetAnimalsVisitedLastMonth()
        {
            DateTime lastMonthStart = DateTime.Now.AddMonths(-1);
            var lastMonthVisits = appointments.Where(a => a.Data >= lastMonthStart);
            if (lastMonthVisits.Any())
            {
                Console.WriteLine("--- Животные, посетившие клинику за последний месяц ---");
                foreach (var visit in lastMonthVisits.Select(v => v.Animal).Distinct())
                {
                    Console.WriteLine($"- {visit.Name} (Владелец: {visit.Owner.FioOwner})");
                }
            }
            else
            {
                Console.WriteLine("За последний месяц клинику никто не посещал.");
            }
        }

        public void GetVeterinariansByPatient()
        {
            Console.Write("Введите имя пациента: ");
            string patientName = Console.ReadLine();
            var patientVisits = appointments.Where(a => a.Animal.Name.Equals(patientName, StringComparison.OrdinalIgnoreCase));
            if (patientVisits.Any())
            {
                Console.WriteLine($"--- Ветеринары, лечившие пациента '{patientName}' ---");
                foreach (var visit in patientVisits.Select(v => v.Veterinarian).Distinct())
                {
                    Console.WriteLine($"- {visit.FioVeter} (Специализация: {visit.Specialisation})");
                }
            }
            else
            {
                Console.WriteLine($"Нет информации о посещениях пациента '{patientName}'.");
            }
        }

        public void GetOwnersWithMultiplePets()
        {
            var ownersWithMultiplePets = owners.Where(o => o.Animals.Count > 1);
            if (ownersWithMultiplePets.Any())
            {
                Console.WriteLine("--- Владельцы, у которых более одного питомца ---");
                foreach (var owner in ownersWithMultiplePets)
                {
                    Console.WriteLine($"- {owner.FioOwner} (Питомцы: {string.Join(", ", owner.Animals.Select(a => a.Name))})");
                }
            }
            else
            {
                Console.WriteLine("Нет владельцев с более чем одним питомцем.");
            }
        }

        public void GetTotalCostByOwnerAndPet()
        {
            Console.Write("Введите ФИО владельца: ");
            string ownerName = Console.ReadLine();
            Console.Write("Введите имя питомца: ");
            string petName = Console.ReadLine();

            var owner = owners.FirstOrDefault(o => o.FioOwner.Equals(ownerName, StringComparison.OrdinalIgnoreCase));
            if (owner == null)
            {
                Console.WriteLine($"Владелец с ФИО '{ownerName}' не найден.");
                return;
            }

            var pet = owner.Animals.FirstOrDefault(a => a.Name.Equals(petName, StringComparison.OrdinalIgnoreCase));
            if (pet == null)
            {
                Console.WriteLine($"Питомец '{petName}' не найден у владельца '{ownerName}'.");
                return;
            }

            var totalCost = appointments.Where(a => a.Animal == pet).Sum(a => a.Cost);
            Console.WriteLine($"Сумма, выплаченная владельцем '{ownerName}' за лечение питомца '{petName}': {totalCost} руб.");
        }

        public void GetMostFrequentDiagnoses()
        {
            var frequentDiagnoses = appointments
                .GroupBy(a => a.Diagnosis)
                .OrderByDescending(g => g.Count())
                .Take(5); // Показать топ 5 самых частых диагнозов

            if (frequentDiagnoses.Any())
            {
                Console.WriteLine("--- Самые частые диагнозы ---");
                foreach (var diagnosis in frequentDiagnoses)
                {
                    Console.WriteLine($"- Диагноз: {diagnosis.Key}, Количество: {diagnosis.Count()}");
                }
            }
            else
            {
                Console.WriteLine("Нет зарегистрированных диагнозов.");
            }
        }

        public void GetTotalRevenue()
        {
            decimal totalRevenue = appointments.Sum(a => a.Cost);
            Console.WriteLine($"Общая выручка клиники: {totalRevenue} руб.");
        }

        public void HireVeterinarian()
        {
            Console.Write("Введите ФИО нового ветеринара: ");
            string fio = Console.ReadLine();
            Console.Write("Введите специализацию нового ветеринара: ");
            string specialization = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fio) || string.IsNullOrWhiteSpace(specialization))
            {
                Console.WriteLine("Все поля должны быть заполнены.");
                return;
            }

            if (veterinarians.Any(v => v.FioVeter.Equals(fio, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"Ветеринар с ФИО '{fio}' уже работает в клинике.");
                return;
            }

            int nextVeterinarianId = veterinarians.Count > 0 ? veterinarians.Last().IdVeter + 1 : 1;
            veterinarians.Add(new Veterinarian(nextVeterinarianId, fio, specialization));
            Console.WriteLine($"Ветеринар '{fio}' успешно принят на работу.");
        }

        public void FireVeterinarian()
        {
            Console.Write("Введите ФИО ветеринара для увольнения: ");
            string fio = Console.ReadLine();

            var veterinarianToRemove = veterinarians.FirstOrDefault(v => v.FioVeter.Equals(fio, StringComparison.OrdinalIgnoreCase));

            if (veterinarianToRemove != null)
            {
                veterinarians.Remove(veterinarianToRemove);
                // Опционально: обработка записей уволенного ветеринара
                Console.WriteLine($"Ветеринар '{fio}' успешно уволен.");
            }
            else
            {
                Console.WriteLine($"Ветеринар с ФИО '{fio}' не найден.");
            }
        }
        public void SaveDataToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("--- Животные ---");
                    foreach (var animal in animals)
                    {
                        writer.WriteLine($"ID: {animal.IdAnimal}, Кличка: {animal.Name}, Вид: {animal.Species}, Порода: {animal.Breed}, Возраст: {animal.Age}, Владелец: {animal.Owner.FioOwner} (ID: {animal.Owner.IdOwner})");
                    }
                    writer.WriteLine();

                    writer.WriteLine("--- Владельцы ---");
                    foreach (var owner in owners)
                    {
                        writer.WriteLine($"ID: {owner.IdOwner}, ФИО: {owner.FioOwner}, Телефон: {owner.Phone}, Питомцы: {string.Join(", ", owner.Animals.Select(a => a.Name))} (ID: {string.Join(", ", owner.Animals.Select(a => a.IdAnimal))})");
                    }
                    writer.WriteLine();

                    writer.WriteLine("--- Ветеринары ---");
                    foreach (var veterinarian in veterinarians)
                    {
                        writer.WriteLine($"ID: {veterinarian.IdVeter}, ФИО: {veterinarian.FioVeter}, Специализация: {veterinarian.Specialisation}");
                        if (veterinarian.HistoryAppointments.Any())
                        {
                            writer.WriteLine("  История приемов:");
                            foreach (var appointment in veterinarian.HistoryAppointments)
                            {
                                writer.WriteLine($"    ID: {appointment.IdAppointment}, Питомец: {appointment.Animal.Name} (ID: {appointment.Animal.IdAnimal}), Дата: {appointment.Data.ToShortDateString()}, Диагноз: {appointment.Diagnosis}, Лечение: {appointment.Medication}, Стоимость: {appointment.Cost}");
                            }
                        }
                        else
                        {
                            writer.WriteLine("  История приемов отсутствует.");
                        }
                    }
                    writer.WriteLine();

                    writer.WriteLine("--- Приемы ---");
                    foreach (var appointment in appointments)
                    {
                        writer.WriteLine($"ID: {appointment.IdAppointment}, Питомец: {appointment.Animal.Name} (ID: {appointment.Animal.IdAnimal}), Ветеринар: {appointment.Veterinarian.FioVeter} (ID: {appointment.Veterinarian.IdVeter}), Дата: {appointment.Data.ToShortDateString()}, Диагноз: {appointment.Diagnosis}, Лечение: {appointment.Medication}, Стоимость: {appointment.Cost}");
                    }

                    Console.WriteLine($"Данные успешно записаны в файл '{filePath}'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при записи в файл: {ex.Message}");
            }
        }
    }
}