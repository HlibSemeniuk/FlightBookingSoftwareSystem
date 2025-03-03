using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Custom;

namespace Credit_Card_System
{
    [Serializable]
    class Credit_Card
    {
        string credit_card_number;/*unique*/
        DateTime expiry_date;
        decimal balance; // Змінюємо тип на decimal

        public string Credit_Card_Number
        {
            get { return credit_card_number; }
            set
            {
                // Додаємо валідацію для номера картки (не порожній)
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Credit card number cannot be empty.", nameof(Credit_Card_Number));
                }
                credit_card_number = value;
            }
        }

        public DateTime Expiry_Date
        {
            get { return expiry_date; }
            set
            {
                // Додаємо валідацію для дати (не в минулому)
                if (value < DateTime.Now.Date)
                {
                    throw new ArgumentException("Expiry date cannot be in the past.", nameof(Expiry_Date));
                }
                expiry_date = value;
            }
        }
        public decimal Balance
        {
            get { return balance; }
            set
            {
                // Додаємо валідацію для балансу (не від'ємний)
                if (value < 0)
                {
                    throw new ArgumentException("Balance cannot be negative.", nameof(Balance));
                }
                balance = value;
            }
        }


        public Credit_Card(string arg1, DateTime arg2, decimal arg3)
        {
            Credit_Card_Number = arg1;
            Expiry_Date = arg2;
            Balance = arg3;
        }
        public override string ToString()
        {
            return " Credit Card Number: " + Credit_Card_Number + "\n Expiry Date: " + Expiry_Date + "\n Balance: " + Balance + "$\n";
        }
    }

    class Credit_Card_Processor
    {
        static int number_of_credit_cards;
        // Визначаємо константу для імені файлу
        private const string CreditCardsDataFile = "CreditCards.data";

        public static int Number_Of_Credit_Cards
        {
            get { return number_of_credit_cards; }
            set { number_of_credit_cards = value; }
        }


        public static void Save_Card(Credit_Card arg1)
        {
            // Використовуємо константу CreditCardsDataFile
            using (FileStream credit_card_stream = new FileStream(CreditCardsDataFile, FileMode.Append, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();

                try
                {
                    bf.Serialize(credit_card_stream, arg1);
                }

                finally
                {
                    credit_card_stream.Close();
                    number_of_credit_cards++;
                }
            }
        }

        public static Credit_Card Load_Card()
        {
            BinaryFormatter bf = new BinaryFormatter();

            // Використовуємо константу CreditCardsDataFile
            using (FileStream credit_card_stream = new FileStream(CreditCardsDataFile, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    Credit_Card c1 = (Credit_Card)bf.Deserialize(credit_card_stream);
                    return c1;
                }

                finally
                {
                    credit_card_stream.Close();
                }
            }

        }
        public static void Add_Card(string arg1, DateTime arg2, decimal arg3)
        {
            try
            {
                Credit_Card c1 = new Credit_Card(arg1, arg2, arg3);
                Credit_Card_Processor.Save_Card(c1);
            }

            finally
            {
                //return " Card Added (success indication)"
            }
        }

        static Credit_Card_Processor()
        {
            number_of_credit_cards = Custom_Data.Number_Of_Credit_Cards;
        }
    }
}
