using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PubSubAccess<TEvent> : MonoBehaviour,
IPubAccess<TEvent>,
ISubAccess<IPubAccess<TEvent>>
{
/********** Data **********/
    protected HashSet<IPubAccess<TEvent>> subscribers = new HashSet<IPubAccess<TEvent>>();

    protected bool unsub = true;
    protected Queue<IPubAccess<TEvent>> unsubQueue = new Queue<IPubAccess<TEvent>>();
    
/********** Construction **********/
    protected virtual void initPubSub()
    {
        this.subscribers = new HashSet<IPubAccess<TEvent>>();

        this.unsub = true;
        this.unsubQueue = new Queue<IPubAccess<TEvent>>();
    }

/********** Subscription **********/
    public virtual void subscribe(IPubAccess<TEvent> endPoint)
    {
        this.subscribers.Add(endPoint);
    }

    public virtual void unsubscribe(IPubAccess<TEvent> endPoint)
    {
        if(this.unsub == true)
            this.subscribers.Remove(endPoint);
        else
            this.unsubQueue.Enqueue(endPoint);
    }

/********** Publishing **********/
    public virtual void publishEvent(TEvent e)
    {
        int subCount = this.subscribers.Count;
        if(subCount > 0)
        {
            this.unsub = false;
            foreach(IPubAccess<TEvent> endPoint in this.subscribers)
            {
                endPoint.publishEvent(e);
            }

            this.unsub = true;
            int  unsubCount = unsubQueue.Count;
            while(unsubCount > 0)
            {
                this.unsubscribe(this.unsubQueue.Dequeue());
            }
        }
    }
}
