﻿var CACHE_STATIC_NAME = 'static-v74';
var CACHE_DYNAMIC_NAME = 'dynamic-v74';
var filesToCache = [
    '/',
     '/Home/contact.html'
];

self.addEventListener('install', function (event) {
    console.log('Installing Service Worker ...', event);
    event.waitUntil(
        caches.open(CACHE_STATIC_NAME)
            .then(function (cache) {
                console.log('Precaching App Shell');
                cache.addAll(filesToCache);
            })
    )
});

self.addEventListener('activate', function (event) {
    console.log('Activating Service Worker ....', event);
    event.waitUntil(
        caches.keys()
            .then(function (keyList) {
                return Promise.all(keyList.map(function (key) {
                    if (key !== CACHE_STATIC_NAME && key !== CACHE_DYNAMIC_NAME) {
                        console.log('Removing old cache.', key);
                        return caches.delete(key);
                    }
                }));
            })
    );
    return self.clients.claim();
});

self.addEventListener('fetch', function (event) {
    event.respondWith(
        // Try the network
        fetch(event.request)
            .then(function (res) {
                return caches.open(CACHE_DYNAMIC_NAME)
                    .then(function (cache) {
                        // Put in cache if succeeds
                        cache.put(event.request.url, res.clone());
                        return res;
                    })
            })
            .catch(function (err) {
                // Fallback to cache
                return caches.match(event.request);
            })
    );
});

self.addEventListener('push', function (event) {
    const promiseChain = self.registration.showNotification('naRatunek - pomoc pod ręką');

    event.waitUntil(promiseChain);
});