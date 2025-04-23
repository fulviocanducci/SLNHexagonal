namespace Application.DTOs.Id
{
   public class RouteId<T>
   {
      public T Id { get; private set; }
      public RouteId(T id)
      {
         Id = id;
      }

      public static RouteId<T> Create(T id)
      {
         return new RouteId<T>(id);
      }
   }
}
