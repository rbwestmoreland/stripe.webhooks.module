Stripe.Webhooks.Module
===
A simple no config http module that listens for [stripe.com](https://stripe.com) webhooks and provides a simple subscription model.

Quick Start
---
    PM> Install-Package Stripe.Webhooks.Module

Then in your `Global.asax.cs` subscribe to stripe events.

    using Stripe.Webhooks.Module;
    
    protected void Application_Start()  
    {  
        StripeEvents.Any = (stripeEvent, eventType) =>
                {
                    //all stripe events
                };
        StripeEvents.CustomerCreated = (stripeEvent) =>
                {
                    //customer.created event
                };
    }

Then create a webhook on [stripe.com](https://stripe.com) that points to `http://www.your-site.com/stripe-webhooks`. 

That's it!

Customization
---

By default `Stripe.Webhooks.Module` listens at `/stripe-webhooks`. You can override it like so:

    StripeWebhookModule.Route = "/my-custom-route";