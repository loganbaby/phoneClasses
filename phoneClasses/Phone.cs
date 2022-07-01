using System;
using System.Collections.Generic;

namespace phoneClasses
{
    internal class Phone : Exceptions.PhoneExceptions
    {
        private static SortedDictionary<string, string> phoneMap = new SortedDictionary<string, string>();
        public static void add()
        {
            string phoneNumber = "";
            do {
                try
                {
                    System.Console.WriteLine("Enter your phone number");
                    System.Console.Write(">>> ");
                    phoneNumber = System.Console.ReadLine();

                    if (!phoneChecker.IsMatch(phoneNumber))
                    {
                        throw new Exception(throwWrongPhoneString());
                    }
                }

                catch(Exception x)
                {
                    System.Console.WriteLine($"Exception: " + x.Message);
                }
            } while (!phoneChecker.IsMatch(phoneNumber));

            System.Console.WriteLine("Enter the name of your contact");
            System.Console.Write(">>> ");
            string contactName = System.Console.ReadLine();

            phoneMap.Add(phoneNumber, contactName);
            System.Console.WriteLine("Success! Press 'Enter' to continue...");
            Console.ReadLine();
        }

        private enum ChooseCalling
        {
            NAME = 1,
            PHONE_NUMBER
        }

        private static ChooseCalling getChoosing()
        {
            System.Console.WriteLine(System.Convert.ToUInt16(ChooseCalling.NAME) + "# Name of the contact");
            System.Console.WriteLine(System.Convert.ToUInt16(ChooseCalling.PHONE_NUMBER) + "# Phone number");
            System.Console.Write(">>> ");
            return (ChooseCalling)System.Convert.ToUInt16(System.Console.ReadLine());
        }

        public static void call()
        {
            ChooseCalling choose = getChoosing();

            switch (choose)
            {
                case ChooseCalling.NAME:
                    System.Console.WriteLine("Enter the name of your contact:");
                    System.Console.Write(">>> ");
                    string contactName = System.Console.ReadLine();

                    try
                    {
                        if (Exceptions.DictionaryExtentions.IsNullOrEmpty(phoneMap))
                        {
                            throw new Exception(Exceptions.DictionaryExtentions.throwNullOrEmptyString());
                        }
                        foreach (var contact in phoneMap)
                        {
                            if (contact.Value == contactName)
                            {
                                System.Console.WriteLine("CALL TO " + contact.Key + " - " + contact.Value);
                                System.Console.ReadKey();
                            }
                        }
                    }

                    catch (Exception x)
                    {
                        System.Console.WriteLine(x.Message);
                    }
                    break;

                case ChooseCalling.PHONE_NUMBER:
                    System.Console.WriteLine("Enter the phone number of your contact:");
                    System.Console.Write(">>> ");
                    string phoneNumber = System.Console.ReadLine();

                    try
                    {
                        if (Exceptions.DictionaryExtentions.IsNullOrEmpty(phoneMap)) {
                            throw new Exception(Exceptions.DictionaryExtentions.throwNullOrEmptyString());
                        }

                        foreach (var contact in phoneMap)
                        {
                            if (contact.Key == phoneNumber)
                            {
                                System.Console.WriteLine("CALL TO " + contact.Key + " - " + contact.Value);
                                System.Console.ReadKey();
                            }
                        }
                    }

                    catch(Exception x)
                    {
                        System.Console.WriteLine(x.Message);
                    }
                    break;
            }
        }

        private static void sendSms(KeyValuePair<string, string> contact)
        {
            System.Console.WriteLine("Enter the text of SMS:");
            System.Console.Write(">>> ");
            string smsText = System.Console.ReadLine();

            System.Console.WriteLine("SMS TO: " + contact.Key + " - " + contact.Value);
            System.Console.WriteLine("SMS: " + smsText);
        }

        private static void makeDecision(int counter)
        {
            if (counter >= 1)
            {
                System.Console.WriteLine("Success! Press 'Enter' to continue...");
                Console.ReadLine();
            }

            else
            {
                System.Console.WriteLine("Nothing to find! Press 'Enter' to continue...");
                Console.ReadLine();
            }
        }

        public static void sms()
        {
            ChooseCalling choose = getChoosing();

            switch (choose)
            {
                case ChooseCalling.PHONE_NUMBER:
                    System.Console.WriteLine("Enter the phone number of your contact:");
                    System.Console.Write(">>> ");
                    string phoneNumber = System.Console.ReadLine();

                    try
                    {
                        if (Exceptions.DictionaryExtentions.IsNullOrEmpty(phoneMap))
                        {
                            throw new Exception(Exceptions.DictionaryExtentions.throwNullOrEmptyString());
                        }

                        int counterPhones = 0;
                        foreach (var contact in phoneMap)
                        {
                            if (contact.Key == phoneNumber)
                            {
                                sendSms(contact);
                                ++counterPhones;
                            }
                        }

                        makeDecision(counterPhones);
                    }

                    catch (Exception x)
                    {
                        System.Console.WriteLine(x.Message);
                    }
                    break;

                case ChooseCalling.NAME:
                    System.Console.WriteLine("Enter the name of your contact:");
                    System.Console.Write(">>> ");
                    string contactName = System.Console.ReadLine();

                    try
                    {
                        if (Exceptions.DictionaryExtentions.IsNullOrEmpty(phoneMap))
                        {
                            throw new Exception(Exceptions.DictionaryExtentions.throwNullOrEmptyString());
                        }

                        int counterNames = 0;
                        foreach (var contact in phoneMap)
                        {
                            if (contact.Value == contactName)
                            {
                                sendSms(contact);
                                ++counterNames;
                            }
                        }

                        makeDecision(counterNames);
                    }

                    catch (Exception x)
                    {
                        System.Console.WriteLine(x.Message);
                    }
                    break;
            }
        }

        public static void showPhoneBook()
        {
            try
            {
                if (Exceptions.DictionaryExtentions.IsNullOrEmpty(phoneMap))
                {
                    throw new Exception(Exceptions.DictionaryExtentions.throwNullOrEmptyString());
                }

                int counter = 1;
                foreach (var contact in phoneMap)
                {
                    System.Console.WriteLine(counter + "# " + contact.Key + " - " + contact.Value);
                    ++counter;
                }
            }

            catch(Exception x)
            {
                System.Console.WriteLine(x.Message);
            }

            System.Console.WriteLine("Press 'Enter' to continue...");
        }
    }
}    //namespace phoneClasses
