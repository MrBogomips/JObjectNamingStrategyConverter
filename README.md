# JObject NamingStrategy PoC

Newtonsoft default serializer doesn't honour the NamingStrategy
for JObject object.

In this PoC we've implemented a simple JObject Custom Converter
that force to reinterpret JObject's properties name with
a provided NamingStrategy.
