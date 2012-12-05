using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;

namespace stripe_webhook_module
{
    public class StripeWebhookModule : IHttpModule
    {
        /// <summary>
        /// default: /stripe-webhooks
        /// </summary>
        public static string Route { get; set; }
        /// <summary>
        /// on exception encountered
        /// </summary>
        public static Action<Exception> OnException { get; set; }

        public void Init(HttpApplication context)
        {
            Route = "/stripe-webhooks";
            context.BeginRequest += context_BeginRequest;
        }

        private static void context_BeginRequest(object sender, EventArgs e)
        {
            var context = (HttpApplication)sender;

            if (context != null)
            if (context.Request.Path.Equals(Route, StringComparison.OrdinalIgnoreCase))
            if (context.Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    using (var reader = new StreamReader(context.Request.InputStream))
                    {
                        var requestBody = reader.ReadToEnd();
                        dynamic json = JsonConvert.DeserializeObject(requestBody);
                        HandleEvent(json);
                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
                finally
                {
                    context.Response.StatusCode = 200;
                    context.Response.End();
                }
            }
        }

        private static void HandleException(Exception ex)
        {
            try
            {
                OnException(ex);
            }
            catch { }
        }

        private static void HandleEvent(dynamic json)
        {
            try
            {
                var type = (string)json.type;

                Events.Any(json, type);

                switch (type)
                {
                    case "account.updated":
                        Events.AccountUpdated(json);
                        break;
                    case "account.application.deauthorized":
                        Events.AccountApplicationDeauthorized(json);
                        break;
                    case "charge.succeeded":
                        Events.ChargeSucceeded(json);
                        break;
                    case "charge.failed":
                        Events.ChargeFailed(json);
                        break;
                    case "charge.refunded":
                        Events.ChargeRefunded(json);
                        break;
                    case "charge.dispute.created":
                        Events.ChargeDisputeCreated(json);
                        break;
                    case "charge.dispute.updated":
                        Events.ChargeDisputeUpdated(json);
                        break;
                    case "charge.dispute.closed":
                        Events.ChargeDisputeClosed(json);
                        break;
                    case "customer.created":
                        Events.CustomerCreated(json);
                        break;
                    case "customer.updated":
                        Events.CustomerUpdated(json);
                        break;
                    case "customer.deleted":
                        Events.CustomerDeleted(json);
                        break;
                    case "customer.subscription.created":
                        Events.CustomerSubscriptionCreated(json);
                        break;
                    case "customer.subscription.updated":
                        Events.CustomerSubscriptionUpdated(json);
                        break;
                    case "customer.subscription.deleted":
                        Events.CustomerSubscriptionDeleted(json);
                        break;
                    case "customer.subscription.trial_will_end":
                        Events.CustomerSubscriptionTrial_Will_End(json);
                        break;
                    case "customer.discount.created":
                        Events.CustomerDiscountCreated(json);
                        break;
                    case "customer.discount.updated":
                        Events.CustomerDiscountUpdated(json);
                        break;
                    case "customer.discount.deleted":
                        Events.CustomerDiscountDeleted(json);
                        break;
                    case "invoice.created":
                        Events.InvoiceCreated(json);
                        break;
                    case "invoice.updated":
                        Events.InvoiceUpdated(json);
                        break;
                    case "invoice.payment_succeeded":
                        Events.InvoicePayment_Succeeded(json);
                        break;
                    case "invoice.payment_failed":
                        Events.InvoicePayment_Failed(json);
                        break;
                    case "invoiceitem.created":
                        Events.InvoiceItemCreated(json);
                        break;
                    case "invoiceitem.updated":
                        Events.InvoiceItemUpdated(json);
                        break;
                    case "invoiceitem.deleted":
                        Events.InvoiceItemDeleted(json);
                        break;
                    case "plan.created":
                        Events.PlanCreated(json);
                        break;
                    case "plan.updated":
                        Events.PlanUpdated(json);
                        break;
                    case "plan.deleted":
                        Events.PlanDeleted(json);
                        break;
                    case "coupon.created":
                        Events.CouponCreated(json);
                        break;
                    case "coupon.deleted":
                        Events.CouponDeleted(json);
                        break;
                    case "transfer.created":
                        Events.TransferCreated(json);
                        break;
                    case "transfer.updated":
                        Events.TransferUpdated(json);
                        break;
                    case "transfer.failed":
                        Events.TransferFailed(json);
                        break;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Dispose()
        {
        }
    }
}
