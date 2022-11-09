using library;
using System.Reflection;

// загружаем нашу сборку
Assembly theAssembly = Assembly.Load(new AssemblyName("Lab_07"));

// функция для записи информации в файл
void AppendXML(string output){
    File.AppendAllText("AssemblyInfo.xml", output + "\n");
}

// перетираем файл и начинаем писать
File.Delete("AssemblyInfo.xml");
AppendXML("<Lab07>");
AppendXML(theAssembly.FullName);



// для каждого типа в сборке
foreach (Type definedType in theAssembly.ExportedTypes)
{
// если это клас
    if (definedType.GetTypeInfo().IsClass)
    {
        // класс такой-то наследован от тех то
        AppendXML($"\n<class> {definedType.Name} : {definedType.BaseType}");
        // получаем его атрибуты
        IEnumerable<MyAttribute> attributes = definedType.GetTypeInfo().GetCustomAttributes().OfType<MyAttribute>().ToArray();
        // если они есть то пишем коммент
        if (attributes.Count() > 0)
        {
            foreach (MyAttribute attribute in attributes)
            {
                AppendXML($"<comment>{attribute.Comment}</comment>");
            }
        }
        // выводим инфу о методах
        foreach (MethodInfo method in definedType.GetMethods())
        {
            AppendXML($"<method>{(method.IsStatic ? "static " : "")}{(method.IsVirtual ? "virtual " : "")}{method.ReturnType.Name} {method.Name} ()</method>");
        }
        AppendXML("</class>");
    }
}

AppendXML("</Lab07>");
