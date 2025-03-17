export interface Response<T> {
  succeded: boolean;
  message: string;
  errors: string[];
  data: T;
}
