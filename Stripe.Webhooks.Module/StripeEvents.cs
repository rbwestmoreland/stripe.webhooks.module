using System;

namespace Stripe.Webhooks.Module
{
    public static class StripeEvents
    {
        /// <summary>
        /// all events
        /// </summary>
        public static Action<dynamic, string> Any { get; set; }
        /// <summary>
        /// account.updated - describes an account Occurs whenever an account has changed status.
        /// </summary>
        public static Action<dynamic> AccountUpdated { get; set; }
        /// <summary>
        /// account.application.deauthorized - describes an application Occurs whenever a user deauthorizes an application. Sent to the related application only.
        /// </summary>
        public static Action<dynamic> AccountApplicationDeauthorized { get; set; }
        /// <summary>
        /// charge.succeeded - describes a charge Occurs whenever a new charge is created and is successful.
        /// </summary>
        public static Action<dynamic> ChargeSucceeded { get; set; }
        /// <summary>
        /// charge.failed - describes a charge Occurs whenever a failed charge attempt occurs.
        /// </summary>
        public static Action<dynamic> ChargeFailed { get; set; }
        /// <summary>
        /// charge.refunded - describes a charge Occurs whenever a charge is refunded, including partial refunds.
        /// </summary>
        public static Action<dynamic> ChargeRefunded { get; set; }
        /// <summary>
        /// charge.dispute.created - describes a disputeOccurs whenever a customer disputes a charge with their bank (chargeback)
        /// </summary>
        public static Action<dynamic> ChargeDisputeCreated { get; set; }
        /// <summary>
        /// charge.dispute.updated - describes a disputeOccurs when the dispute is updated (usually with evidence)
        /// </summary>
        public static Action<dynamic> ChargeDisputeUpdated { get; set; }
        /// <summary>
        /// charge.dispute.closed - describes a disputeOccurs when the dispute is resolved and the dispute status changes to won or lost
        /// </summary>
        public static Action<dynamic> ChargeDisputeClosed { get; set; }
        /// <summary>
        /// customer.created - describes a customer Occurs whenever a new customer is created.
        /// </summary>
        public static Action<dynamic> CustomerCreated { get; set; }
        /// <summary>
        /// customer.updated - describes a customer Occurs whenever any property of a customer changes.
        /// </summary>
        public static Action<dynamic> CustomerUpdated { get; set; }
        /// <summary>
        /// customer.deleted - describes a customer Occurs whenever a customer is deleted.
        /// </summary>
        public static Action<dynamic> CustomerDeleted { get; set; }
        /// <summary>
        /// customer.subscription.created - describes a subscription Occurs whenever a customer with no subscription is signed up for a plan.
        /// </summary>
        public static Action<dynamic> CustomerSubscriptionCreated { get; set; }
        /// <summary>
        /// customer.subscription.updated - describes a subscription Occurs whenever a subscription changes. Examples would include switching from one plan to another, or switching status from trial to active.
        /// </summary>
        public static Action<dynamic> CustomerSubscriptionUpdated { get; set; }
        /// <summary>
        /// customer.subscription.deleted - describes a subscription Occurs whenever a customer ends their subscription.
        /// </summary>
        public static Action<dynamic> CustomerSubscriptionDeleted { get; set; }
        /// <summary>
        /// customer.subscription.trial_will_end - describes a subscription Occurs three days before the trial period of a subscription is scheduled to end.
        /// </summary>
        public static Action<dynamic> CustomerSubscriptionTrial_Will_End { get; set; }
        /// <summary>
        /// customer.discount.created - describes a discount Occurs whenever a coupon is attached to a customer.
        /// </summary>
        public static Action<dynamic> CustomerDiscountCreated { get; set; }
        /// <summary>
        /// customer.discount.updated - describes a discount Occurs whenever a customer is switched from one coupon to another.
        /// </summary>
        public static Action<dynamic> CustomerDiscountUpdated { get; set; }
        /// <summary>
        /// customer.discount.deleted - describes a discount Occurs whenever a customer's discount is removed.
        /// </summary>
        public static Action<dynamic> CustomerDiscountDeleted { get; set; }
        /// <summary>
        /// invoice.created - describes an invoice Occurs whenever a new invoice is created.
        /// </summary>
        public static Action<dynamic> InvoiceCreated { get; set; }
        /// <summary>
        /// invoice.updated - describes an invoice Occurs whenever an invoice changes (for example, the amount could change).
        /// </summary>
        public static Action<dynamic> InvoiceUpdated { get; set; }
        /// <summary>
        /// invoice.payment_succeeded - describes an invoice Occurs whenever an invoice attempts to be paid, and the payment succeeds.
        /// </summary>
        public static Action<dynamic> InvoicePayment_Succeeded { get; set; }
        /// <summary>
        /// invoice.payment_failed - describes an invoice Occurs whenever an invoice attempts to be paid, and the payment fails.
        /// </summary>
        public static Action<dynamic> InvoicePayment_Failed { get; set; }
        /// <summary>
        /// invoiceitem.created - describes an invoice item Occurs whenever an invoice item is created.
        /// </summary>
        public static Action<dynamic> InvoiceItemCreated { get; set; }
        /// <summary>
        /// invoiceitem.updated - describes an invoice item Occurs whenever an invoice item is updated.
        /// </summary>
        public static Action<dynamic> InvoiceItemUpdated { get; set; }
        /// <summary>
        /// invoiceitem.deleted - describes an invoice item Occurs whenever an invoice item is deleted.
        /// </summary>
        public static Action<dynamic> InvoiceItemDeleted { get; set; }
        /// <summary>
        /// plan.created - describes a plan Occurs whenever a plan is created.
        /// </summary>
        public static Action<dynamic> PlanCreated { get; set; }
        /// <summary>
        /// plan.updated - describes a plan Occurs whenever a plan is updated.
        /// </summary>
        public static Action<dynamic> PlanUpdated { get; set; }
        /// <summary>
        /// plan.deleted - describes a plan Occurs whenever a plan is deleted.
        /// </summary>
        public static Action<dynamic> PlanDeleted { get; set; }
        /// <summary>
        /// coupon.created - describes a coupon Occurs whenever a coupon is created.
        /// </summary>
        public static Action<dynamic> CouponCreated { get; set; }
        /// <summary>
        /// coupon.deleted - describes a coupon Occurs whenever a coupon is deleted.
        /// </summary>
        public static Action<dynamic> CouponDeleted { get; set; }
        /// <summary>
        /// transfer.created - describes a transfer Occurs whenever a new transfer is created.
        /// </summary>
        public static Action<dynamic> TransferCreated { get; set; }
        /// <summary>
        /// transfer.updated - describes a transfer Occurs whenever the amount of a pending transfer is updated.
        /// </summary>
        public static Action<dynamic> TransferUpdated { get; set; }
        /// <summary>
        /// transfer.failed - describes a transfer Occurs whenever Stripe attempts to send a transfer and that transfer fails.
        /// </summary>
        public static Action<dynamic> TransferFailed { get; set; }
    }
}
