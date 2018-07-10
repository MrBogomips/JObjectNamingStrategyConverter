using System;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace jobject_poc {
    class Program {
        private const string json = @"
        {
            'SimpleString': 'Value',
            'Ciccio': [1, 2, 'buffo'],
            'CalpurnioSiculo': {
                'AbraCadaBra': true
            },
            'i_Am_an_Ugly_Snake': {
                'i_am_a_cool_snake': 'yeah'	
            }
        }
        ";

        static JObject GetData () => JObject.Parse (json);
        static void Main (string[] args) {
            var obj = new ModelSample {
                AncientAge = 666,
                FirstName = "Calpurnio",
                CustomData = GetData ()
            };

            Console.WriteLine ("NOT WORKING SNAKE CASE (JObject's properties aren't serialized accordingly");
            BadExample (obj);
            Console.WriteLine ("\n\nWORKING SNAKE CASE");
            SnakeCaseSample (obj);
        }

        static void BadExample (object obj) {
            var snakeNameStrategy = new SnakeCaseNamingStrategy ();
            var jsonSnakeSettings = new JsonSerializerSettings {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver {
                NamingStrategy = snakeNameStrategy
                },
            };

            var json = JsonConvert.SerializeObject (obj, jsonSnakeSettings);
            Console.WriteLine (json);
        }

        static void SnakeCaseSample (object obj) {
            var snakeNameStrategy = new SnakeCaseNamingStrategy ();
            var jsonSnakeSettings = new JsonSerializerSettings {
                Formatting = Formatting.Indented,
                Converters = new [] { new JObjectNamingStrategyConverter (snakeNameStrategy) },
                ContractResolver = new DefaultContractResolver {
                NamingStrategy = snakeNameStrategy
                },
            };

            var json = JsonConvert.SerializeObject (obj, jsonSnakeSettings);
            Console.WriteLine (json);
            return;
        }
    }
}