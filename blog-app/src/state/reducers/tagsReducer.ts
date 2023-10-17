import { ActionTypes, Action } from "../actions/tagTypes";
import { Map, List } from "immutable";

export interface Tag {
  id: number;
  name: string;
}

type InitialState = Map<string, any>;

const initialState: InitialState = Map({
  loading: false,
  tags: List<Tag>(),
  error: null,
});

export const tagsReducer = (
  state: InitialState = initialState,
  action: Action
) => {
  switch (action.type) {
    case ActionTypes.fetchingTag:
      return state.set("loading", true);
    case ActionTypes.fetchTag:
      return state.merge({
        tags: List(action.payload),
        error: null,
        loading: false,
      });
    case ActionTypes.fetchTagError:
      return state.merge({
        error: action.payload,
        loading: false,
      });
    default:
      return state;
  }
};
