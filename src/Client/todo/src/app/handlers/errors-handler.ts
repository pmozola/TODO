import { Injectable, ErrorHandler, Inject, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorsHandler implements ErrorHandler {

  constructor(@Inject(Injector) private readonly injector: Injector) {
  }

  handleError(error: Error | HttpErrorResponse) {
    const router = this.injector.get(Router);
    console.log(error);

    if (error instanceof HttpErrorResponse) {
      if (!navigator.onLine) {
        this.toastrService.error('No Internet Connection', null, { onActivateTick: true });
      }

      // Http Error
      let message;
      if (environment.production === true) {
        message = `Sorry but error occurees : ${error.error.message}`;
      } else {
        message = `Sorry but error occurees : ${error.error.message}`;
      }

      this.toastrService.error(message, null, { onActivateTick: true });
    } else {
      router.navigate(['/error/app']);
      this.toastrService.error(error.message, null, { onActivateTick: true });
    }
  }

  private get toastrService(): ToastrService {
    return this.injector.get(ToastrService);
  }
}
