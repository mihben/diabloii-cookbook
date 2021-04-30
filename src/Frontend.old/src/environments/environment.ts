// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  settings: {
    backend:{
        uri: "http://localhost:5000"
    },
    authorization :{
        issuer: "https://eu.battle.net/oauth",
        clientId: "e74e669060b7418aa8ca66ac7ba82395",
        clientSecret: "veq2ngqk3WhqFhq8iylHZm8FDFp0ZRh1"
    }
}
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
