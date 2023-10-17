import { Author } from "../reducers/authorsReducer";

export interface FetchAuthorsAction {
  type: ActionTypes.fetchAuthors;
  payload: Author[];
}

export interface FetchingAuthorsAction {
  type: ActionTypes.fetchingAuthors;
}

export interface FetchAuthorsErrorAction {
  type: ActionTypes.fetchAuthorsError;
  payload: any;
}

export enum ActionTypes {
  fetchAuthors,
  fetchingAuthors,
  fetchAuthorsError,
}

export type Action =
  | FetchAuthorsAction
  | FetchingAuthorsAction
  | FetchAuthorsErrorAction;
