# JObject NamingStrategy PoC

Newtonsoft default serializer doesn't honour the NamingStrategy
for `JObject` objects.

In this PoC I've implemented a simple JObject Custom Converter
that force to reinterpret JObject's properties name with
a provided NamingStrategy.

## Output
```
NOT WORKING SNAKE CASE (JObject's properties aren't serialized accordingly
{
  "first_name": "Calpurnio",
  "ancient_age": 666,
  "custom_data": {
    "SimpleString": "Value",
    "Ciccio": [
      1,
      2,
      "buffo"
    ],
    "CalpurnioSiculo": {
      "AbraCadaBra": true
    },
    "i_Am_an_Ugly_Snake": {
      "i_am_a_cool_snake": "yeah"
    }
  }
}


WORKING SNAKE CASE
{
  "first_name": "Calpurnio",
  "ancient_age": 666,
  "custom_data": {
    "simple_string": "Value",
    "ciccio": [
      1,
      2,
      "buffo"
    ],
    "calpurnio_siculo": {
      "abra_cada_bra": true
    },
    "i_am_an_ugly_snake": {
      "i_am_a_cool_snake": "yeah"
    }
  }
}
```
