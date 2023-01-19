using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.TechnicalStuff.Crud.Operations.Results;

namespace MyCompany.Crm.TechnicalStuff.Crud.Api
{
    public static class CrudControllerExtensions
    {
        private const string DefaultCreatedAtAction = "Read";
        private const string DefaultCreatedAtController = null;
        private static readonly Func<CrudEntity, object> DefaultRouteValuesFactory = e => new {id = e.Id};

        [PublicAPI]
        public static async Task<ActionResult<TEntity>> ToCreatedAtActionResult<TEntity>(
            this Task<Created<TEntity>> createPromise)
            where TEntity : CrudEntity =>
            ToCreatedAtActionResult(
                await createPromise,
                DefaultCreatedAtAction,
                DefaultCreatedAtController,
                DefaultRouteValuesFactory);

        [PublicAPI]
        public static async Task<ActionResult<TEntity>> ToCreatedAtActionResult<TEntity>(
            this Task<Created<TEntity>> createPromise,
            Func<TEntity, object> routeValuesFactory)
            where TEntity : CrudEntity =>
            ToCreatedAtActionResult(
                await createPromise,
                DefaultCreatedAtAction,
                DefaultCreatedAtController,
                routeValuesFactory);

        [PublicAPI]
        public static async Task<ActionResult<TEntity>> ToCreatedAtActionResult<TEntity>(
            this Task<Created<TEntity>> createPromise,
            string actionName)
            where TEntity : CrudEntity =>
            ToCreatedAtActionResult(
                await createPromise,
                actionName,
                DefaultCreatedAtController,
                DefaultRouteValuesFactory);

        [PublicAPI]
        public static async Task<ActionResult<TEntity>> ToCreatedAtActionResult<TEntity>(
            this Task<Created<TEntity>> createPromise,
            string actionName,
            Func<TEntity, object> routeValuesFactory)
            where TEntity : CrudEntity =>
            ToCreatedAtActionResult(
                await createPromise,
                actionName,
                DefaultCreatedAtController,
                routeValuesFactory);

        [PublicAPI]
        public static async Task<ActionResult<TEntity>> ToCreatedAtActionResult<TEntity>(
            this Task<Created<TEntity>> createPromise,
            string actionName,
            string controllerName,
            Func<TEntity, object> routeValuesFactory)
            where TEntity : CrudEntity =>
            ToCreatedAtActionResult(
                await createPromise,
                actionName,
                controllerName,
                routeValuesFactory);

        private static ActionResult<TEntity> ToCreatedAtActionResult<TEntity>(Created<TEntity> created,
            string actionName,
            string controllerName,
            Func<TEntity, object> routeValuesFactory)
            where TEntity : CrudEntity =>
            new CreatedAtActionResult(
                actionName,
                controllerName,
                routeValuesFactory,
                created.Entity);

        [PublicAPI]
        public static async Task<ActionResult<TEntity>> ToOkResult<TEntity>(this Task<Created<TEntity>> createPromise)
            where TEntity : CrudEntity
        {
            var created = await createPromise;
            return new OkObjectResult(created.Entity);
        }

        [PublicAPI]
        public static async Task<ActionResult<TEntity>> ToOkResult<TEntity>(this Task<TEntity> readPromise) =>
            new(await readPromise);

        [PublicAPI]
        public static async Task<ActionResult<TEntity>> ToOkResult<TEntity>(this Task<Updated<TEntity>> updatePromise)
            where TEntity : class
            => new(await updatePromise);

        [PublicAPI]
        public static async Task<NoContentResult> ToNoContentResult(this Task<Updated> updatePromise)
        {
            await updatePromise;
            return new NoContentResult();
        }

        [PublicAPI]
        public static async Task<OkResult> ToOkResult(this Task<Updated> updatePromise)
        {
            await updatePromise;
            return new OkResult();
        }

        [PublicAPI]
        public static async Task<NoContentResult> ToNoContentResult<TEntity>(this Task<Updated<TEntity>> updatePromise)
            where TEntity : class
        {
            await updatePromise;
            return new NoContentResult();
        }

        [PublicAPI]
        public static async Task<StatusCodeResult> ToStatusCodeResult(this Task<Deleted> deletePromise)
        {
            await deletePromise;
            return new NoContentResult();

            // var deleted = await deletePromise;
            // return deleted.WasPresent ? (StatusCodeResult) new NoContentResult() : new NotFoundResult();
        }

        [PublicAPI]
        public static async Task<OkResult> ToOkResult(this Task<Deleted> deletePromise)
        {
            await deletePromise;
            return new OkResult();
        }
    }
}