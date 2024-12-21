# *Projects* and *Namespaces*

1. All names should be as short as possible and without information noise.
2. Company / product name should be present in: *Solution name* (*MyCompany.Crm*), *Assembly name* (*MyCompany.CRM.Sales.Domain.dll*), *Root namespace* (*MyCompany.CRM.Sales*), but it's better not to add it to the project name (*Sales*).
3. The project name should starts with the *Bounded Context* name (*Sales* or *Sales.Adapters.RestApi*).
4. Projects should reflect architectural divisions (e.g. project per layer). Relations between projects should follow used architectural style.
5. Projects should expose only what is actually needed. By default, *internal* visibility should be used instead of *public*.
6. *Namespaces* should tell a business story, not a technical one. They should starts with the name of the company / product followed by the name of the *Bounded Context*. The rest of the namespace should reflect the hierarchical division into *Modules* (*MyCompany.CRM.Sales.Orders*).
7. *Namespace* **should not** contain names reflecting architectural divisions that are already present in project names (*.Domain*, *.Adapters.Sql*).

Thanks to this approach just a glance at *Solution Explorer* gives us a lot of information about the system and the business. The names of all components are as short as possible, which makes navigation much easier. In addition, each technical element of the code has a clear responsibility and you know what kind of information you can expect from it. The system is divided hierarchically according to the divisions in the business.