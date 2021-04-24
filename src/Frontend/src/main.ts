import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';
import { environmentLoader as environmentLoaderPromise } from './environments/environmentLoader';

environmentLoaderPromise.then((env) => {
  environment.settings = env.settings;

  if (env.production) {
      enableProdMode();
  } else {
      console.log(environment);
  }

  platformBrowserDynamic()
      .bootstrapModule(AppModule)
      .catch((err) => console.error(err));
});