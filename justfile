_default:
  just --list

# Install all depedencies
install-all: _install-subabase

_install-subabase:
  brew install supabase/tap/supabase

# Start the application
up:
  supabase start